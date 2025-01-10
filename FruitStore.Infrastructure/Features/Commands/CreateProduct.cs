using FruitStore.Application.Contracts.Product;
using FruitStore.Application.DTOs;
using MediatR;

namespace FruitStore.Infrastructure.Features.Commands;

public static class CreateProduct
{
    public sealed record Command(string Name, decimal Price, string Description, CategoryRequest Category) : IRequest<EmptyResponse>;

    public sealed class Handler(IProductRepository productRepo) : IRequestHandler<Command, EmptyResponse>
    {
        private readonly IProductRepository _productRepo = productRepo;

        public async Task<EmptyResponse> Handle(Command request, CancellationToken cancellationToken)
        {
            var newProd = new CreateProductRequest
            {
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                Category = request.Category,
            };
            var res = await _productRepo.CreateProductAsync(newProd);
            return res.Value;
        }
    }
}
