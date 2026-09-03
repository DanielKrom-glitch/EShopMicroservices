using Microsoft.AspNetCore.Mvc.Filters;

namespace Catalog.API.Products.GetProductsById;

public record GetProductByIdResponse(Product Product);


internal class GetProductsByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetProductByIdQuery(id));

            var response = result.Adapt<GetProductByIdResponse>();
            return Results.Ok(response);
        })
        .WithName("GetProductById")
        .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get a product by ID")
        .WithDescription("Get a product by ID");
    }
}
