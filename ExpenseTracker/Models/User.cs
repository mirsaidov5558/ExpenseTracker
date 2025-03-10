namespace ExpenseTracker.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public IEnumerable<Transaction> Transactions { get; set; } = new List<Transaction>();
        public string? FirstName { get; internal set; }
        public string? LastName { get; internal set; }
        public string Role { get; internal set; }
    }
}
