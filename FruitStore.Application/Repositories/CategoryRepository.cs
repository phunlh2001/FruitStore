using Ardalis.Specification.EntityFrameworkCore;
using FruitStore.Application.Contracts.Category;
using FruitStore.Application.DTOs;
using FruitStore.Core.Context;
using Microsoft.EntityFrameworkCore;

namespace FruitStore.Application.Repositories
{
    public class CategoryRepository(AppDbContext context) : ICategoryRepository
    {
        private readonly AppDbContext _context = context;
        public async Task<List<CategoryResponse>> GetAllCategoryAsync()
        {
            var cates = await _context.Categories.ToListAsync();
            var res = cates.Select(c => new CategoryResponse
            {
                Id = c.Id,
                Name = c.Name,
            }).ToList();

            return res;
        }
    }
}
