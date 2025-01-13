namespace FruitStore.Application.DTOs;
public class UpdateProductRequest
{
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public required string Description { get; set; }

    public CategoryRequest Category { get; set; }
}
