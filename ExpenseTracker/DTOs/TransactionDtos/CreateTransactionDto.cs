using ExpenseTracker.Enums;

namespace ExpenseTracker.DTOs.TransactionDtos
{
    public class CreateTransactionDto
    {
        public Guid CategoryId { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public DateTime Date {  get; set; }
        public string Note { get; set; }
    }
}
