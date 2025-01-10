using FruitStore.Application.Contracts.Category;
using FruitStore.Application.DTOs;
using MediatR;

namespace FruitStore.Infrastructure.Features.Queries;

public static class GetAllCategory
{
    public sealed class Query() : IRequest<List<CategoryResponse>>;

    public sealed class Handler(ICategoryRepository repo) : IRequestHandler<Query, List<CategoryResponse>>
    {
        private readonly ICategoryRepository _repo = repo;
        public async Task<List<CategoryResponse>> Handle(Query request, CancellationToken cancellationToken)
        {
            var res = await _repo.GetAllCategoryAsync();
            return res;
        }
    }
}
