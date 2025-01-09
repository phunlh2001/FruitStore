using System.Reflection;
using FastEndpoints;
using FastEndpoints.Swagger;
using FruitStore.Application.Repositories;
using FruitStore.Core.Context;
using FruitStore.Infrastructure.Handlers;
using FruitStore.Infrastructure.Interfaces;

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
    cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
    cfg.RegisterServicesFromAssemblyContaining<CreateProductHandler>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddFastEndpoints().AddSwaggerDocument();

builder.Services.AddScoped<IProductService, GetProductHandler>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();
app.UseFastEndpoints().UseSwaggerGen();
app.UseCors(originName);

app.Run();
