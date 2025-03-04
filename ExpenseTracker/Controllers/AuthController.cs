using ExpenseTracker.DTOs.UserDtos;
using ExpenseTracker.Models;
using ExpenseTracker.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private static List<User> _users = new();
        private readonly JwtService _jwtService;

        public AuthController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegisterDto dto)
        {
            if (_users.Any(u => u.Email == dto.Email))
                return BadRequest("Пользователь уже существует!");

            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password) // Хешируем пароль
            };

            _users.Add(user);
            return Ok("Пользователь зарегистрирован!");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDto dto)
        {
            var existingUser = _users.FirstOrDefault(u => u.Email == dto.Email);
            if (existingUser == null || !BCrypt.Net.BCrypt.Verify(dto.Password, existingUser.PasswordHash))
                return Unauthorized("Неверный логин или пароль!");

            var token = _jwtService.GenerateToken(existingUser);
            return Ok(new { Token = token });
        }
    }
}
