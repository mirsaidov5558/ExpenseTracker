using ExpenseTracker.Enums;

namespace ExpenseTracker.DTOs.TransactionDtos
{
    public class CreateTransactionDto
    {
        public int UserId { get; set; } // ID пользователя, совершающего транзакцию
        public Guid CategoryId { get; set; } // ID категории
        public decimal Amount { get; set; } // Сумма транзакции
        public DateTime Date { get; set; }
        public TransactionType Type { get; set; } = TransactionType.Expense; // Тип транзакции (по умолчанию расход)
        public string Note { get; set; } // Описание транзакции
    }
}
