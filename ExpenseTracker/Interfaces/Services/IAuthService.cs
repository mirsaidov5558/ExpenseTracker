using ExpenseTracker.DTOs.UserDtos;
using System.Data;

namespace ExpenseTracker.Interfaces.Services
{
    public interface IAuthService
    {
        Task<string?> AuthenticateAsync(UserLoginDto loginDto);
        Task<bool> RegisterAsync(UserRegisterDto registerDto);
    }
}
