namespace FruitStore.Application.DTOs
{
    public class CreateProductRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public CategoryRequest Category { get; set; }
    }
}
