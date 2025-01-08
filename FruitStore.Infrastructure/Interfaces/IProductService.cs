using FruitStore.Application.DTOs;

namespace FruitStore.Infrastructure.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductResponse>> GetAllProductsAsync();
        Task<ProductResponse> GetProductByIdAsync(Guid id);
    }
}
