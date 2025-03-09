using ModelsTransaction = ExpenseTracker.Models.Transaction;

namespace ExpenseTracker.Interfaces.Repositories
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<ModelsTransaction>> GetAllAsync(DateTime? startDate = null, DateTime? endDate = null, Guid? categoryId = null);
        Task<ModelsTransaction> GetByIdAsync(Guid id);
        Task AddAsync (ModelsTransaction transaction);
        Task UpdateAsync (ModelsTransaction transaction);
        Task DeleteAsync (Guid id);
    }
}
