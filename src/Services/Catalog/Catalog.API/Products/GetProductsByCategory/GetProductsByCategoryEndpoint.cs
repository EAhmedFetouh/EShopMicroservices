﻿
namespace Catalog.API.Products.GetProductsByCategory;

//public record GetProductsByCategoryRequest(string Category) : IQuery<GetProductsByCategoryResponse>;
public record GetProductsByCategoryResponse(IEnumerable<Product> Products);
public class GetProductsByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{category}", async (string category, ISender sender) =>
        {
            var result = await sender.Send(category);
            var response = result.Adapt<GetProductsByCategoryResponse>();

            return Results.Ok(response);
        })
            .Produces<GetProductsByCategoryResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Products by Category")
            .WithDescription("Get Products by Category");
    }
}
