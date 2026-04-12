
namespace Catalog.Products.GetProducts
{
    public record GetProductResponse(IEnumerable<Product> products);
    public class GetProductEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/Products", async (ISender sender) =>
            {
                var result = await sender.Send(new GetProductQuery());
                var response = result.Adapt<GetProductResponse>();
                return response;

            });
        }
    }
}
