using FruitStore.Application.Contracts.Product;
using FruitStore.Application.DTOs;
using MediatR;

namespace FruitStore.Infrastructure.Features.Queries;

public static class GetProductList
{
    public sealed record Query() : IRequest<List<ProductResponse>>;

    public sealed class Handler(IProductRepository productRepo) : IRequestHandler<Query, List<ProductResponse>>
    {
        private readonly IProductRepository _productRepo = productRepo;
        public async Task<List<ProductResponse>> Handle(Query request, CancellationToken cancellationToken)
        {
            var res = await _productRepo.GetAllProductsAsync();
            return res.Value;
        }
    }
}
