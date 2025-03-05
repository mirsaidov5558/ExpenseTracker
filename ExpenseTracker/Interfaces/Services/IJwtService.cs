using ExpenseTracker.Models;

namespace ExpenseTracker.Interfaces.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
