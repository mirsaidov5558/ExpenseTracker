using ExpenseTracker.Context;
using ExpenseTracker.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using ModelsTransaction = ExpenseTracker.Models.Transaction;


namespace ExpenseTracker.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ExpenseDbContext _context;
        public TransactionRepository(ExpenseDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ModelsTransaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ModelsTransaction>> GetAllAsync(DateTime? startDate = null, DateTime? endDate = null, Guid? categoryId = null)
        {
            var query = _context.Transactions.AsQueryable();

            if (startDate.HasValue)
                query = query.Where(t => t.Date >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(t => t.Date <= endDate.Value);

            if (categoryId.HasValue)
            {                
                var categoryIdInt = Convert.ToInt32(categoryId.Value);

                query = query.Where(t => t.CategoryId == categoryIdInt); 
            }

            return await query.ToListAsync();
        }

        public async Task<ModelsTransaction> GetByIdAsync(Guid id)
        {
            return await _context.Transactions
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task UpdateAsync(ModelsTransaction transaction)
        {
            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();
        }
    }
}
