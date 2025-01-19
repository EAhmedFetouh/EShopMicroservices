namespace Catalog.API.Products.DeleteProduct;

public record DeleteProductQuery(Guid Id) : ICommand<DeleteProductResult>;
public record DeleteProductResult(bool IsSuccess);
public class DeleteProductCommandHandler
    (IDocumentSession session)
    :  ICommandHandler<DeleteProductQuery, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductQuery command, CancellationToken cancellationToken)
    {
        session.Delete<Product>(command.Id);
        await session.SaveChangesAsync(cancellationToken);
        return new DeleteProductResult(true);
    }
}
