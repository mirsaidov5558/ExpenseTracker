using ExpenseTracker.Enums;

namespace ExpenseTracker.DTOs.CategoryDtos
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public TransactionType Type { get; set; }
    }
}
