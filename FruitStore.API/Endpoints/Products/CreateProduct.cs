using FastEndpoints;
using FruitStore.Application.DTOs;

namespace FruitStore.API.Endpoints.Products
{
    public class CreateProduct : Endpoint<CreateProductRequest, ProductResponse>
    {
        public override void Configure()
        {
            Post("/api/products/create");
            AllowAnonymous();
            Description(t => t.WithTags("Products"));
        }

        public override async Task HandleAsync(CreateProductRequest req, CancellationToken ct)
        {
            var fakeData = new ProductResponse
            {
                Id = Guid.NewGuid(),
                Name = req.Name,
                CategoryName = req.CategoryName,
                Description = req.Description,
                Price = req.Price
            };

            await SendAsync(fakeData);
        }
    }
}
