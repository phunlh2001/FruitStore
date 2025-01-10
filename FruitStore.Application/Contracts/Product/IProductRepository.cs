using ErrorOr;
using FruitStore.Application.DTOs;

namespace FruitStore.Application.Contracts.Product
{
    public interface IProductRepository
    {
        Task<ErrorOr<List<ProductResponse>>> GetAllProductsAsync();
        Task<ErrorOr<ProductResponse>> GetProductByIdAsync(Guid id);
        Task<ErrorOr<EmptyResponse>> CreateProductAsync(CreateProductRequest request);
        Task<ErrorOr<EmptyResponse>> DeleteProductAsync(Guid id);
    }
}
