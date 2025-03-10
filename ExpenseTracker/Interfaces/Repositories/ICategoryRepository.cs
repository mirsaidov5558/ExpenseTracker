using ExpenseTracker.Models;

namespace ExpenseTracker.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync(Guid userId);
        Task<Category> GetByIdAsync(Guid id);
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(Guid id);

    }
}
