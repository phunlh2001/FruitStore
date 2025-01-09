using ErrorOr;
using FruitStore.Application.DTOs;

namespace FruitStore.Application.Repositories
{
    public interface IProductRepository
    {
        Task<ErrorOr<List<ProductResponse>>> GetAllProductsAsync();
        Task<ErrorOr<ProductResponse>> GetProductByIdAsync(Guid id);
        Task<ErrorOr<ProductResponse>> CreateProductAsync(CreateProductRequest request);
    }
}
