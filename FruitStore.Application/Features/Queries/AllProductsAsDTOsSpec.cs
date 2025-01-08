using Ardalis.Specification;
using FruitStore.Application.DTOs;
using FruitStore.Core.Entities;

namespace FruitStore.Application.Features.Queries
{
    public class AllProductsAsDTOsSpec : Specification<Product, ProductResponse>
    {
        public AllProductsAsDTOsSpec()
        {
            Query.Include(p => p.Category);
            Query.Select(p => new ProductResponse
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Description = p.Description,
                CategoryName = p.Category!.Name
            });
        }
    }
}
