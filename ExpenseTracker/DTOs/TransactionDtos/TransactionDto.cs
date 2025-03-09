using ExpenseTracker.Enums;

namespace ExpenseTracker.DTOs.TransactionDtos
{
    public class TransactionDto
    {
        public Guid Id { get; set; } // ID транзакции
        public int UserId { get; set; } // ID пользователя, совершающего транзакцию
        public int CategoryId { get; set; } // ID категории
        public decimal Amount { get; set; } // Сумма транзакции
        public TransactionType Type { get; set; } // Тип транзакции (расход/доход)
        public DateTime Date { get; set; } // Дата транзакции
        public string Note { get; set; } // Описание транзакции
    }
}
