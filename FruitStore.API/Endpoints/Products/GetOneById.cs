using FastEndpoints;
using FruitStore.Application.DTOs;
using FruitStore.Infrastructure.Interfaces;

namespace FruitStore.API.Endpoints.Products
{
    public class GetOneById(IProductService productService) : EndpointWithoutRequest<ProductResponse>
    {
        private readonly IProductService _productService = productService;
        public override void Configure()
        {
            Get("/api/products/{id}");
            AllowAnonymous();
            Description(d => d.WithTags("Products"));
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var id = Route<Guid>("id");
            var res = await _productService.GetProductByIdAsync(id);

            await SendAsync(res);
        }
    }
}
