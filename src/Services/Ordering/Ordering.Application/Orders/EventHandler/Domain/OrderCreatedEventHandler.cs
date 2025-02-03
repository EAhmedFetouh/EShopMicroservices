namespace Ordering.Application.Orders.EventHandler.Domain;
public class OrderCreatedEventHandler(ILogger<OrderCreatedEventHandler> logger)
    : INotificationHandler<OrderCreatedEvent>
{
    public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Order Event handled : {DomainEvent}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}
