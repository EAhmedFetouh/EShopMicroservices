﻿

namespace Basket.API.Basket.DeleteBasket;

//public record  DeleteBasketRequest(string UserName) : ICommand<DeleteBasketResult>;
public record DeleteBasketResponse(bool IsSuccess);
public class DeleteBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/basket/{username}", async (string UserName, ISender sender) =>
         {
             var command = new DeleteBasketCommand(UserName);
             var result = await sender.Send(command);
             var response = result.Adapt<DeleteBasketResponse>();
             return Results.Ok(response);
         })
             .WithName("DeleteBasket")
             .Produces<DeleteBasketResponse>(StatusCodes.Status200OK)
             .ProducesProblem(StatusCodes.Status400BadRequest)
             .ProducesProblem(StatusCodes.Status404NotFound)
             .WithSummary("Delete Basket")
             .WithDescription("Delete Basket");
    }
}