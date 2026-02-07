using BuildingBlocks.Cqrs;
using Catalog.Data;


namespace Catalog.Produt.CreateProduct
{
    public record createProductCommand(string name,List<string>categroy,string description,string  fileName,decimal price):Icommand<createProductResult>;
    public record createProductResult(Guid id);

    internal class CreateProductCommandHandler : ICommandHandler<createProductCommand, createProductResult>
    {
        public async Task<createProductResult> Handle(createProductCommand request, CancellationToken cancellationToken)
        {
            //Create New Entity
            var product = new Product
            {
                Name= request.name,
                Description=request.description,
                Price=request.price,
                Category=request.categroy,
                ImageFiles=request.fileName
            };
            //todo
            //save into Db
            return new createProductResult(Guid.NewGuid());
        }
    }
}
