
namespace Catalog.Products.GetProductById
{
    public record GetProductResult(Product Product);
    public class GetProductByIdEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}",async (Guid id,ISender sender) =>
            {
                var result = await sender.Send(new GetProductByIdQuery(id));
                var response = result.Adapt<GetProductResult>();
                return response;
            });
        }
    }
}
