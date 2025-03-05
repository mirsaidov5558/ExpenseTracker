using ExpenseTracker.Context;
using ExpenseTracker.Interfaces.Repositories;
using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;
using System;

public class UserRepository : IUserRepository
{
    private readonly ExpenseDbContext _context;
	public UserRepository(ExpenseDbContext context)
	{
        _context = context;
	}

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }
}
