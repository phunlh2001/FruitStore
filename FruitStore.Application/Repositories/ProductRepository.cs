using Ardalis.Specification.EntityFrameworkCore;
using ErrorOr;
using FruitStore.Application.DTOs;
using FruitStore.Application.Features.Queries;
using FruitStore.Core.Context;
using Microsoft.EntityFrameworkCore;

namespace FruitStore.Application.Repositories
{
    public class ProductRepository(AppDbContext context) : IProductRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<ErrorOr<List<ProductResponse>>> GetAllProductsAsync()
        {
            var data = await _context.Products.WithSpecification(new AllProductsAsDTOsSpec()).ToListAsync();
            if (data.Count == 0)
            {
                return Error.NotFound("Empty data");
            }
            return Task.FromResult(data).Result;
        }

        public async Task<ErrorOr<ProductResponse>> GetProductByIdAsync(Guid id)
        {
            var data = await _context.Products.WithSpecification(new GetProductByIdSpec(id)).FirstOrDefaultAsync();
            if (data == null)
            {
                return Error.NotFound("Failed to get product by id!");
            }
            return Task.FromResult(data).Result;
        }
    }
}
