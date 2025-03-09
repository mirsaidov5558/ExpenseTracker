using ExpenseTracker.Enums;

namespace ExpenseTracker.DTOs.TransactionDtos
{
    public class UpdateTransactionDto
    {
        public int CategoryId { get; set; } // ID категории
        public decimal Amount { get; set; } // Сумма транзакции
        public TransactionType Type { get; set; } // Тип транзакции (можно изменять)
        public string Note { get; set; } // Описание транзакции
    }
}
