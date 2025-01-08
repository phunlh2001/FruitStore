using Ardalis.Specification;
using FruitStore.Application.DTOs;
using FruitStore.Core.Entities;

namespace FruitStore.Application.Features.Queries
{
    public class GetProductByIdSpec : Specification<Product, ProductResponse>
    {
        public GetProductByIdSpec(Guid id)
        {
            Query.Where(s => s.Id == id);
            Query.Select(s => new ProductResponse
            {
                Id = s.Id,
                Name = s.Name,
                Price = s.Price,
                Description = s.Description,
                CategoryName = s.Category!.Name
            });
        }
    }
}
