using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        [HttpGet("profile")]
        public IActionResult GetProfile() 
        {
            var userEmail = User.Identity?.Name;
            return Ok(new { Email = userEmail, Message = "Это защищенный маршрут!" });
        }
    }
}
