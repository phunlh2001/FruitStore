using Ardalis.Specification;
using FruitStore.Core.Entities;

namespace FruitStore.Application.Specifications
{
    public class GetOnlyProductByIdSpec : Specification<Product>
    {
        public GetOnlyProductByIdSpec(Guid id)
        {
            Query.Where(s => s.Id == id);
        }
    }
}
