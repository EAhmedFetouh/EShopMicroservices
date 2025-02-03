using MediatR;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Ordering.Infrastructure.Interceptors;
public class DispatchDomainEventsInterceptor(IMediator mediator) :  SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        DispatchDominEvents(eventData.Context).GetAwaiter().GetResult();
        return base.SavingChanges(eventData, result);
    }

    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        await DispatchDominEvents(eventData.Context);
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    public async Task DispatchDominEvents(DbContext? context)
    {
        if(context == null) return;

        var aggregates=context.ChangeTracker.Entries<IAggregate>()
            .Select(x => x.Entity)
            .Where(x => x.DomainEvents.Any())
            .ToArray();

        var domainEvents= aggregates
            .SelectMany(x => x.DomainEvents)
            .ToList();

        aggregates.ToList().ForEach(x => x.ClearDomainEvents());

        foreach (var domainEvent in domainEvents)
             await mediator.Publish(domainEvent);
        
    }
}
