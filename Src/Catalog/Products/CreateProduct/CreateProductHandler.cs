


namespace Catalog.Products.CreateProduct
{
    public record createProductCommand(string name,List<string>categroy,string description,string  fileName,decimal price):Icommand<createProductResult>;
    public record createProductResult(Guid id);
    public class createProductValidator : AbstractValidator<createProductCommand>
    {
        public createProductValidator()
        {
            RuleFor(x => x.name)
              .NotEmpty().WithMessage("Name is required")
              .MinimumLength(3);

            RuleFor(x => x.categroy)
                .NotNull().WithMessage("Category is required")
                .Must(c => c.Count > 0).WithMessage("At least one category is required");

            RuleFor(x => x.description)
                .NotEmpty()
                .MaximumLength(500);

            RuleFor(x => x.fileName)
                .NotEmpty()
                .Must(BeValidFile).WithMessage("Invalid file format");

            RuleFor(x => x.price)
                .GreaterThan(0).WithMessage("Price must be greater than zero");
        }

        private bool BeValidFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return false;

            var allowedExtensions = new[] { ".jpg", ".png", ".jpeg" };
            return allowedExtensions.Any(ext => fileName.EndsWith(ext));
        }
    }
    internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<createProductCommand, createProductResult>
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
            session.Store(product);
           await session.SaveChangesAsync(cancellationToken);
            return new createProductResult(product.Id);
        }
    }
}
