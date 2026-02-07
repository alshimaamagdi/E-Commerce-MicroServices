using Carter;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Catalog.Produt.CreateProduct
{

        public record createProductRequest(string name, List<string> categroy, string description, string fileName, decimal price) : IRequest<createProductResponse>;
        public record createProductResponse(Guid id);
       public class CreateProductEndPoint : ICarterModule
       {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/Products", async (createProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<createProductCommand>();
                var result = await sender.Send(command);
                var response= result.Adapt<createProductResponse>();
                return Results.Created($"/products/{response.id}",response);
            })
           .WithName("CreateProduct")
           .Produces<createProductResponse>(StatusCodes.Status201Created)
           .ProducesProblem(StatusCodes.Status400BadRequest)
           .WithSummary("Create Product")
           .WithDescription("Create Product");
            
        }
       }

}
