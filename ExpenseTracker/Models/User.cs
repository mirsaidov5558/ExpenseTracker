namespace ExpenseTracker.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public IEnumerable<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
