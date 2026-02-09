using Marten.Linq.QueryHandlers;

namespace Catalog.Products.GetProducts
{
 
        public record GetProductQuery():Iquery<GetProductResult>;
        public record GetProductResult(IEnumerable<Product> Products);

    public class GetProductHandler(IDocumentSession session,ILogger<GetProductHandler>logger) : IQueryHandler<GetProductQuery, GetProductResult>
    {
        public async Task<GetProductResult> Handle(GetProductQuery Query, CancellationToken cancellationToken)
        {
            logger.LogInformation("Get Product Query Handle @query",Query);
            var products=await session.Query<Product>().ToListAsync(cancellationToken);
            return new GetProductResult(products);
        }
    }

}
