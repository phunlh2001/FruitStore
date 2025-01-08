using FastEndpoints;
using FruitStore.Application.DTOs;
using FruitStore.Infrastructure.Interfaces;

namespace FruitStore.API.Endpoints.Products
{
    public class GetList(IProductService productService) : EndpointWithoutRequest<List<ProductResponse>>
    {
        private readonly IProductService _productService = productService;
        public override void Configure()
        {
            Get("/api/products");
            AllowAnonymous();
            Description(d => d.WithTags("Products"));
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var res = await _productService.GetAllProductsAsync();

            await SendAsync(res);
        }
    }
}
