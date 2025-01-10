using FruitStore.Application.Contracts.Product;
using FruitStore.Application.DTOs;
using MediatR;

namespace FruitStore.Infrastructure.Features.Queries;

public static class GetOneProductById
{
    public sealed record Query(Guid id) : IRequest<ProductResponse>;

    public sealed class Handler(IProductRepository productRepo) : IRequestHandler<Query, ProductResponse>
    {
        private readonly IProductRepository _productRepo = productRepo;

        public async Task<ProductResponse> Handle(Query request, CancellationToken cancellationToken)
        {
            var res = await _productRepo.GetProductByIdAsync(request.id);
            return res.Value;
        }
    }
}
