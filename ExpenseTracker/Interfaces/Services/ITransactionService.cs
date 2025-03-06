using ExpenseTracker.DTOs.TransactionDtos;

namespace ExpenseTracker.Interfaces.Services
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDto>> GetAllAsync();
        Task<TransactionDto> GetByIdAsync(Guid id);
        Task AddAsync(CreateTransactionDto transactionDto);
        Task UpdateAsync(Guid id, CreateTransactionDto transactionDto);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<TransactionDto>> GetAllFilteredAsync(DateTime? startDate, DateTime? endDate, Guid? categoryId);
    }
}
