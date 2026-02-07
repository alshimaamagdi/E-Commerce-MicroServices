using Carter;
using Catalog.Produt.CreateProduct;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});
TypeAdapterConfig.GlobalSettings
    .NewConfig<createProductResult, createProductResponse>()
    .Map(dest => dest.id, src => src.id);
var app = builder.Build();

app.MapCarter();
app.Run();
