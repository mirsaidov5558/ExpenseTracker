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
        public async Task<ActionResult<IEnumerable<TransactionDto>>> GetAllAsync([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate, [FromQuery] Guid? categoryId)
        {
            var transactions = await _transactionService.GetAllAsync(startDate, endDate, categoryId);
            return Ok(transactions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionDto>> GetByIdAsync(Guid id)
        {
            try
            {
                var transaction = await _transactionService.GetByIdAsync(id);
                return Ok(transaction);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Транзакция не найдена.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] CreateTransactionDto transactionDto)
        {
            await _transactionService.AddAsync(transactionDto);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = transactionDto.UserId }, transactionDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAsync(Guid id, [FromBody] UpdateTransactionDto transactionDto)
        {
            try
            {
                await _transactionService.UpdateAsync(id, transactionDto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Транзакция не найдена.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            try
            {
                await _transactionService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Транзакция не найдена.");
            }
        }
    }
}
