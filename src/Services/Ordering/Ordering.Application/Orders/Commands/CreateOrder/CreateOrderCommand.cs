using BuildingBlocks.CQRS;
using FluentValidation;


namespace Ordering.Application.Orders.Commands.CreateOrder;

public record CreateOrderCommand(OrderDto Order) : ICommand<CreateOrderResult>;
public record CreateOrderResult(Guid Id);

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x=>x.Order.OrderName).NotEmpty().WithName("Name is required");
        RuleFor(x=>x.Order.CustomerId).NotEmpty().WithName("CustomerId is required");
        RuleFor(x=>x.Order.OrderItems).NotEmpty().WithName("Name is required");
    }
}
