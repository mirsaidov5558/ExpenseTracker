using ExpenseTracker.Context;
using ExpenseTracker.Interfaces.Repositories;
using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;
using System;

public class CategoryRepository : ICategoryRepository
{
	private readonly ExpenseDbContext _context;

    public CategoryRepository(ExpenseDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category != null)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Category>> GetAllAsync(Guid userId)
    {
        return await _context.Categories.Where(x => x.UserId == userId).ToListAsync();
    }

    public async Task<Category> GetByIdAsync(Guid id)
    {
        return await _context.Categories.FindAsync(id);
    }

    public async Task UpdateAsync(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
    }
}
