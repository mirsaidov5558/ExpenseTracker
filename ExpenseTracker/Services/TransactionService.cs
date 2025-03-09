using ExpenseTracker.DTOs.TransactionDtos;
using ExpenseTracker.Exception;
using ExpenseTracker.Interfaces.Repositories;
using ExpenseTracker.Interfaces.Services;
using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            UserId = transactionDto.UserId,
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
        var transaction = await _transactionRepository.GetByIdAsync(id);
        if (transaction == null)
            throw new NotFoundException("Транзакция не найдена.");

        await _transactionRepository.DeleteAsync(id);
    }

    public Task<IEnumerable<TransactionDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TransactionDto>> GetAllAsync(DateTime? startDate = null, DateTime? endDate = null, Guid? categoryId = null)
    {
        var transactions = await _transactionRepository.GetAllAsync(startDate, endDate, categoryId);

        // Преобразование модели в DTO
        var transactionDtos = new List<TransactionDto>();
        foreach (var transaction in transactions)
        {
            transactionDtos.Add(new TransactionDto
            {
                Id = transaction.Id,
                UserId = transaction.UserId,
                CategoryId = transaction.CategoryId,
                Amount = transaction.Amount,
                Type = transaction.Type,
                Date = transaction.Date,
                Note = transaction.Note
            });
        }

        return transactionDtos;
    }

    

    public async Task<TransactionDto> GetByIdAsync(Guid id)
    {
        var transaction = await _transactionRepository.GetByIdAsync(id);

        if (transaction == null)
            throw new KeyNotFoundException("Транзакция не найдена.");

        return new TransactionDto
        {
            Id = transaction.Id,
            UserId = transaction.UserId,
            CategoryId = transaction.CategoryId,
            Amount = transaction.Amount,
            Type = transaction.Type,
            Date = transaction.Date,
            Note = transaction.Note
        };
    }

    public async Task UpdateAsync(Guid id, UpdateTransactionDto transactionDto)
    {
        var transaction = await _transactionRepository.GetByIdAsync(id);
        if (transaction == null)
            throw new NotFoundException("Транзакция не найдена.");

        transaction.CategoryId = transactionDto.CategoryId;
        transaction.Amount = transactionDto.Amount;
        transaction.Type = transactionDto.Type;
        transaction.Note = transactionDto.Note;

        await _transactionRepository.UpdateAsync(transaction);
    }
}
