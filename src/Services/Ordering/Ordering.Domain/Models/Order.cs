namespace Ordering.Domain.Models;
public class Order : Aggregate<OrderId>
{
    private readonly List<OrderItem> _orderItems =  new();
    public IReadOnlyList<OrderItem> OrderItems => _orderItems.AsReadOnly();

    public CustomerId CustomerId { get; private set; } = default!;
    public OrderName OrderName { get; private set; } = default!;
    public Address ShippingAddress { get; private set; } = default!;
    public Address BuildingAdress { get; private set; } = default!;
    public Payment Payment { get; private set; } = default!;
    public OrderStatus Status { get; private set; } = OrderStatus.Pending;

    public decimal TotalPrice { 
        get => _orderItems.Sum(x => x.Price);
        private set { }
    }


    public static Order Create(OrderId id,CustomerId customerId, OrderName orderName, Address shippingAddress, Address buildingAdress, Payment payment, List<OrderItem> orderItems)
    {
        var order = new Order()
        {
            Id=id,
            CustomerId = customerId,
            OrderName = orderName,
            ShippingAddress = shippingAddress,
            BuildingAdress = buildingAdress,
            Payment = payment,
            Status=OrderStatus.Pending
        };
        order.AddDomainEvent(new OrderCreatedEvent(order));
        return order;
    }

    public void Update (Order order, OrderName orderName, Address shippingAddress, Address buildingAdress, Payment payment, List<OrderItem> orderItems)
    {
        order.OrderName = orderName;
        order.ShippingAddress = shippingAddress;
        order.BuildingAdress = buildingAdress;
        order.Payment = payment;
        Status = Status;

        order.AddDomainEvent(new OrderUpdatedEvent(order));
    }

    public void Add(ProductId productId,int quantity, decimal price)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        var orderItem = new OrderItem(Id, productId, quantity, price);
        _orderItems.Add(orderItem);
    }

    public void Remove(ProductId productId) 
    { 
        var orderItem = _orderItems.FirstOrDefault(x => x.ProductId == productId);
        if (orderItem is not null)
        {
            _orderItems.Remove(orderItem);
        }
    }
}
