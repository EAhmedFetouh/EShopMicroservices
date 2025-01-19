namespace Basket.API.Basket.GetBasket;
public record GetBasketQuery(string Username) : IQuery<GetBasketResult>;

public record GetBasketResult(ShoppingCart Cart);
public class GetBasketHandler (IBasketRepository repo) : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
    {
        var basket = await repo.GetBasket(query.Username, cancellationToken);
        return new GetBasketResult(basket);
    }
}
