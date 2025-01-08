using FruitStore.Application.DTOs;
using FruitStore.Application.Repositories;
using FruitStore.Infrastructure.Interfaces;

namespace FruitStore.Infrastructure.Services
{
    public class ProductService(IProductRepository productRepo) : IProductService
    {
        private readonly IProductRepository _productRepo = productRepo;

        public async Task<List<ProductResponse>> GetAllProductsAsync()
        {
            var res = await _productRepo.GetAllProductsAsync();
            return res.Value;
        }

        public async Task<ProductResponse> GetProductByIdAsync(Guid id)
        {
            var res = await _productRepo.GetProductByIdAsync(id);
            return res.Value;
        }
    }
}
