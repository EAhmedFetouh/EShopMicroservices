using BuildingBlocks.Pagination;

namespace Ordering.Application.Orders.Queries.GetOrders;
public class GetOrdersHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetOrdersQuery, GetOrdersResult>
{
    public async Task<GetOrdersResult> Handle(GetOrdersQuery query, CancellationToken cancellationToken)
    {
        var pageIndex = query.PaginationRequest.PageIndex;
        var pageSize = query.PaginationRequest.PageSize;
        var totalCount = await dbContext.Orders.CountAsync(cancellationToken);

        var orders = await dbContext.Orders
            .Include(o => o.OrderItems)
            .OrderBy(o => o.OrderName.Value)
            .Skip(pageIndex * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        var paginatedOrders =
            new PaginatedResult<OrderDto>
            (pageIndex, 
            pageSize,
            totalCount,
            orders.ToOrderDtoList());
        return new GetOrdersResult(paginatedOrders);

    }
}
