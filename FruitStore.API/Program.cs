using FastEndpoints;
using FastEndpoints.Swagger;
using FruitStore.Application.Contracts.Category;
using FruitStore.Application.Contracts.Product;
using FruitStore.Application.Repositories;
using FruitStore.Core.Context;
using FruitStore.Infrastructure.Features.Commands;

var originName = "AllowAllOrigins";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddCors(c =>
{
    c.AddPolicy(originName, o =>
    {
        o.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    });
});

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<CreateProduct.Handler>();
    cfg.RegisterServicesFromAssemblyContaining<DeleteProductById.Handler>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddFastEndpoints().AddSwaggerDocument();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

var app = builder.Build();
app.UseFastEndpoints().UseSwaggerGen();
app.UseCors(originName);

app.Run();
