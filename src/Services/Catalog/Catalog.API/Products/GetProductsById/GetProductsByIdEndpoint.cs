namespace Catalog.API.Products.GetProductsById;

public record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdResult>;

public record GetProductByIdResult(Product Product);


internal class GetProductsByIdEndpoint
{
}
