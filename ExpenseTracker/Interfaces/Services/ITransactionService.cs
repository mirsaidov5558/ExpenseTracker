using ExpenseTracker.DTOs.TransactionDtos;

namespace ExpenseTracker.Interfaces.Services
{
    public interface ITransactionService
    {
        
        Task<TransactionDto> GetByIdAsync(Guid id);
        Task AddAsync(CreateTransactionDto transactionDto);
        Task UpdateAsync(Guid id, UpdateTransactionDto transactionDto);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<TransactionDto>> GetAllAsync(DateTime? startDate = null, DateTime? endDate = null, Guid? categoryId = null);
    }
}
