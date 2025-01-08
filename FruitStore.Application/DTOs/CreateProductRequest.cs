namespace FruitStore.Application.DTOs
{
    public record CreateProductRequest(string Name, decimal Price, string Description, string CategoryName);
}
