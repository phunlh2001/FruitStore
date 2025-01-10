using Ardalis.Specification;
using FruitStore.Application.DTOs;
using FruitStore.Core.Entities;

namespace FruitStore.Application.Specifications
{
    public class GetProductWithCategoryByIdSpec : Specification<Product, ProductResponse>
    {
        public GetProductWithCategoryByIdSpec(Guid id)
        {
            Query.Include(s => s.Category);
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
