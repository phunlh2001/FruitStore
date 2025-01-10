using FruitStore.Application.DTOs;

namespace FruitStore.Application.Contracts.Category
{
    public interface ICategoryRepository
    {
        Task<List<CategoryResponse>> GetAllCategoryAsync();
    }
}
