using ExpenseTracker.DTOs.UserDtos;
using ExpenseTracker.Interfaces.Services;
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
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto dto)
        {
            var isRegistered = await _authService.RegisterAsync(dto);
            if (!isRegistered)
                return BadRequest("Пользователь уже существует!");

            return Ok("Пользователь зарегистрирован!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto dto)
        {
            var token = await _authService.AuthenticateAsync(dto);
            if (token == null)
                return Unauthorized("Неверный логин или пароль!");

            return Ok(new { Token = token });
        }
    }
}
