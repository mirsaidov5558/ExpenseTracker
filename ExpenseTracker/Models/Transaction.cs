using ExpenseTracker.Enums;
using System.Diagnostics;

namespace ExpenseTracker.Models
{
    public class Transaction
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; } = TransactionType.Expense;
        public DateTime Date { get; set; } = DateTime.Now;
        public string Note { get; set; }

        public User User { get; set; }
        public Category Category { get; set; }
    }
}
