using Ardalis.Specification.EntityFrameworkCore;
using ErrorOr;
using FruitStore.Application.DTOs;
using FruitStore.Application.Features.Queries;
using FruitStore.Core.Context;
using FruitStore.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FruitStore.Application.Repositories
{
    public class ProductRepository(AppDbContext context) : IProductRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<ErrorOr<ProductResponse>> CreateProductAsync(CreateProductRequest request)
        {
            if (request == null)
            {
                return Error.Unexpected("Request body could not empty");
            }

            var prod = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                Category = new Category
                {
                    Id = Guid.NewGuid(),
                    Name = request.CategoryName,
                }
            };

            _context.Products.Add(prod);
            await _context.SaveChangesAsync();

            return new ProductResponse
            {
                Id = prod.Id,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                CategoryName = request.CategoryName
            };
        }

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
