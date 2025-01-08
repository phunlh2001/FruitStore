namespace FruitStore.Core.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public required string Description { get; set; }

        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
