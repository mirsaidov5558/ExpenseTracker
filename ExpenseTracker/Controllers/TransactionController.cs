using ExpenseTracker.DTOs.TransactionDtos;
using ExpenseTracker.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionDto>>> GetAll(
            [FromQuery] DateTime? startDate,
            [FromQuery] DateTime? endDate,
            [FromQuery] Guid? categoryId)
        {
            var transactions = await _transactionService.GetAllFilteredAsync(startDate, endDate, categoryId);
            return Ok(transactions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionDto>> GetById(Guid id)
        {
            var transaction = await _transactionService.GetByIdAsync(id);
            if (transaction == null)
                return NotFound("Транзакция не найдена");

            return Ok(transaction);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTransactionDto dto)
        {
            await _transactionService.AddAsync(dto);
            return Ok("Транзакция создана");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CreateTransactionDto dto)
        {
            await _transactionService.UpdateAsync(id, dto);
            return Ok("Транзакция обновлена");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _transactionService.DeleteAsync(id);
            return Ok("Транзакция удалена");
        }
    }
}
