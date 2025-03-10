using ExpenseTracker.Models;

namespace ExpenseTracker.Interfaces.Repositories
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetAllAsync();
        Task<Transaction> GetByIdAsync(Guid id);
        Task AddAsync (Transaction transaction);
        Task UpdateAsync (Transaction transaction);
        Task DeleteAsync (Guid id);
        IQueryable<Transaction> GetAllQueryable();
    }
}
