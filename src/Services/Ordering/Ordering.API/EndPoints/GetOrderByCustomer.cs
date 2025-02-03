﻿using Ordering.Application.Orders.Queries.GetOrdersByCustomer;

namespace Ordering.API.EndPoints;

//public record GetOrdersByCustomer(Guid CustomerId);
public record GetOrdersByCustomerResponse(IEnumerable<OrderDto> Orders);
public class GetOrderByCustomer : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders/customer/{customerId}", async (Guid customerId, ISender sender) =>
        {
            var result = await sender.Send(new GetOrdersByCustomerQuery(customerId));
            var response = result.Adapt<GetOrdersByCustomerResponse>();
            return Results.Ok(response);
        })
            .WithName("GetOrderByCustomer")
            .Produces<GetOrdersByCustomerResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Order By Customer")
            .WithDescription("Get Order By Customer");
    }
}

