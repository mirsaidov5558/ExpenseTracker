using ExpenseTracker.Enums;

namespace ExpenseTracker.Models
{
    public class Category
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int UserId { get; set; }
        public TransactionType Type { get; set; } = TransactionType.Expense;

        public User User { get; set; }
        public IEnumerable<Transaction> Transaction { get; set; } = new List<Transaction>();
    }
}
