namespace Ordering.Application.Orders.EventHandler.Domain;
public class OrderUpdatedEventHandler(ILogger<OrderUpdatedEventHandler> logger)
: INotificationHandler<OrderUpdatedEvent>
{
    public Task Handle(OrderUpdatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Order Event handled : {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}