using FruitStore.Application.DTOs;
using FruitStore.Application.Repositories;
using MediatR;

namespace FruitStore.Infrastructure.Handlers
{
    public class CreateProductHandler(IProductRepository productRepo) : IRequestHandler<CreateProductRequest, ProductResponse>
    {
        private readonly IProductRepository _productRepo = productRepo;

        public async Task<ProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var res = await _productRepo.CreateProductAsync(request);
            return res.Value;
        }
    }
}
