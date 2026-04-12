using Catalog.Exceptions;
using Marten.Linq.QueryHandlers;

namespace Catalog.Products.GetProductById
{
    public record GetProductByIdQuery(Guid id):Iquery<GetQueryByIdResult>;
    public record GetQueryByIdResult(Product Product);
    public class GetProductByIdHandler(IDocumentSession session) : IQueryHandler<GetProductByIdQuery, GetQueryByIdResult>
    {
        public async Task<GetQueryByIdResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product=await session.LoadAsync<Product>(request.id, cancellationToken);
            if(product is null)
            {
                throw new ProductNotFundException();
            }
            return new GetQueryByIdResult(product);
        }
    }
}
