﻿using Ardalis.Specification.EntityFrameworkCore;
using ErrorOr;
using FruitStore.Application.Contracts.Product;
using FruitStore.Application.DTOs;
using FruitStore.Application.Specifications;
using FruitStore.Core.Context;
using FruitStore.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FruitStore.Application.Repositories
{
    public class ProductRepository(AppDbContext context) : IProductRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<ErrorOr<EmptyResponse>> CreateProductAsync(CreateProductRequest request)
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
                CategoryId = request.Category.Id,
            };

            _context.Products.Add(prod);
            await _context.SaveChangesAsync();

            return new EmptyResponse();
        }

        public async Task<ErrorOr<EmptyResponse>> DeleteProductAsync(Guid id)
        {
            var prod = await _context.Products.WithSpecification(new GetOnlyProductByIdSpec(id)).FirstOrDefaultAsync();
            if (prod == null)
            {
                return Error.NotFound($"Not found product with id {id}");
            }

            _context.Products.Remove(prod);
            await _context.SaveChangesAsync();

            return new EmptyResponse();
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
            var data = await _context.Products.WithSpecification(new GetProductWithCategoryByIdSpec(id)).FirstOrDefaultAsync();
            if (data == null)
            {
                return Error.NotFound("Failed to get product by id!");
            }
            return Task.FromResult(data).Result;
        }

        public async Task<ErrorOr<EmptyResponse>> UpdateProductAsync(Guid id, UpdateProductRequest request)
        {
            var data = await _context.Products.WithSpecification(new GetProductWithCategoryByIdSpec(id)).FirstOrDefaultAsync();
            if (data == null)
            {
                return Error.NotFound("Failed to get product by id!");
            }

            var prod = new Product
            {
                Id = id,
                Description = request.Description,
                Name = request.Name,
                Price = request.Price,
                CategoryId = request.Category.Id,
            };

            _context.Products.Update(prod);
            await _context.SaveChangesAsync();
            return new EmptyResponse();
        }
    }
}
