﻿using Discount.Grpc;
using static Discount.Grpc.DiscountProtoService;

namespace Basket.API.Basket.StoreBasket;

public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;
public record StoreBasketResult(string UserName);


public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandValidator()
    {
        RuleFor(x => x.Cart).NotNull().WithMessage("Cart can not be null");
        RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("UserName is required");
    }
}

public class StoreBasketCommandHandler 
    (IBasketRepository repo, DiscountProtoServiceClient discountProto) :
    ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {

        await DeductDiscount(command.Cart, cancellationToken);

        var basket = await repo.StoreBasket(command.Cart, cancellationToken);
        return new StoreBasketResult(command.Cart.UserName);
    }

    public async Task DeductDiscount(ShoppingCart cart, CancellationToken cancellationToken)
    {
        //TODO: Communicate with Discount.Grpc
        foreach (var item in cart.Items)
        {
            var coupon = await discountProto.GetDiscountAsync(new GetDiscountRequest { ProductName = item.ProductName });
            item.Price -= coupon.Amount;
        }
    }
}
