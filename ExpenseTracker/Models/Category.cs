using ExpenseTracker.Enums;

namespace ExpenseTracker.Models
{
    public class Category
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public TransactionType Type { get; set; } = TransactionType.Expense;

        public User User { get; set; }
        public IEnumerable<Transaction> Transaction { get; set; } = new List<Transaction>();
    }
}
