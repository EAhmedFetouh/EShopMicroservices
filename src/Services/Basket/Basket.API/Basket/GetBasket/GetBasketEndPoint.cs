namespace Basket.API.Basket.GetBasket;

//public record GetBasketRequest(string UserName) : IRequest<GetBasketResponse>;
public record GetBasketResponse(ShoppingCart Cart);
public class GetBasketEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{username}", async (string UserName, ISender sender) =>
        {
            var result = await sender.Send(new GetBasketQuery(UserName));
            var response = result.Adapt<GetBasketResponse>();
            return Results.Ok(response);
        })
            .WithName("GetBaskets")
            .Produces<GetBasketResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Baskets")
            .WithDescription("Get Baskets");
    }
}
