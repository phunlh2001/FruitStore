using MediatR;

namespace FruitStore.Application.DTOs
{
    public class CreateProductRequest : IRequest<ProductResponse>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
    }
}
