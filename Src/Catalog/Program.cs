

using BuildingBlocks.Behavior;
using Catalog.Products.CreateProduct;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});
TypeAdapterConfig.GlobalSettings
    .NewConfig<createProductResult, createProductResponse>()
    .Map(dest => dest.id, src => src.id);

TypeAdapterConfig<createProductRequest, createProductCommand>
    .NewConfig()
    .Map(dest => dest.name, src => src.name)
    .Map(dest => dest.categroy, src => src.categroy)
    .Map(dest => dest.description, src => src.description)
    .Map(dest => dest.fileName, src => src.fileName)
    .Map(dest => dest.price, src => src.price);
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();
var app = builder.Build();

app.MapCarter();
app.Run();
