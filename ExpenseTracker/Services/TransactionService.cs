using ExpenseTracker.DTOs.TransactionDtos;
using ExpenseTracker.Interfaces.Repositories;
using ExpenseTracker.Interfaces.Services;
using System;
using System.Transactions;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task AddAsync(CreateTransactionDto transactionDto)
    {
        var transaction = new Transaction
        {
            Id = Guid.NewGuid(),
            CategoryId = transactionDto.CategoryId,
            Amount = transactionDto.Amount,
            Type = transactionDto.Type,
            Date = transactionDto.Date,
            Note = transactionDto.Note
        };

        await _transactionRepository.AddAsync(transaction);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _transactionRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<TransactionDto>> GetAllAsync()
    {
        var transactions = await _transactionRepository.GetAllAsync();
        return transactions.Select(t => new TransactionDto
        {
            Id = t.Id,
            Amount = t.Amount,
            Date = t.Date,
            Note = t.Note
        });
    }

    public async Task<IEnumerable<TransactionDto>> GetAllFilteredAsync(DateTime? startDate, DateTime? endDate, Guid? categoryId)
    {
        var query = _transactionRepository.GetAllQueryable();

        if (startDate.HasValue)
            query = query.Where(t => t.Date >= startDate.Value);

        if (endDate.HasValue)
            query = query.Where(t => t.Date <= endDate.Value);

        if (categoryId.HasValue)
            query = query.Where(t => t.CategoryId == categoryId.Value);

        var transactions = await query.ToListAsync();
        return transactions.Select(t => new TransactionDto
        {
            Id = t.Id,
            Amount = t.Amount,
            Date = t.Date,
            Note = t.Note
        });
    }

    public async Task<TransactionDto> GetByIdAsync(Guid id)
    {
        var transaction = await _transactionRepository.GetByIdAsync(id);
        if (transaction == null)
            return null;

        return new TransactionDto
        {
            Id = transaction.Id,
            Amount = transaction.Amount,
            Date = transaction.Date,
            Note = transaction.Note
        };
    }

    public async Task UpdateAsync(Guid id, CreateTransactionDto transactionDto)
    {
        var transaction = new Transaction
        {
            Id = Guid.NewGuid(),
            CategoryId = transactionDto.CategoryId,
            Amount = transactionDto.Amount,
            Type = transactionDto.Type,
            Date = transactionDto.Date,
            Note = transactionDto.Note
        };

        await _transactionRepository.AddAsync(transaction);
    }
}
