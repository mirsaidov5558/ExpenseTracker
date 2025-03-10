using ExpenseTracker.DTOs.CategoryDtos;
using ExpenseTracker.Models;

namespace ExpenseTracker.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync(Guid userId);
        Task<CategoryDto> GetByIdAsync(Guid Id);
        Task AddAsync(CreateCategoryDto categoryDto, Guid userId);
        Task UpdateAsync(UpdateCategoryDto categoryDto);
        Task DeleteAsync(Guid id);
    }
}
