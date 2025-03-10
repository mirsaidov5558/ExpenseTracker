using ExpenseTracker.DTOs.CategoryDtos;
using ExpenseTracker.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExpenseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public Guid UserId => !User.Identity.IsAuthenticated
            ? Guid.Empty
            : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // Получить все категории
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
        {
            var categories = await _categoryService.GetAllAsync(UserId);
            return Ok(categories);
        }

        // Получить категорию по ID
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetById(Guid id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();  // Возвращаем 404, если категория не найдена
            }
            return Ok(category);
        }

        // Добавить новую категорию
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] CreateCategoryDto categoryDto)
        {
            if (categoryDto == null)
            {
                return BadRequest("Invalid category data.");
            }

            await _categoryService.AddAsync(categoryDto, UserId);
            return CreatedAtAction(nameof(GetById), new { id = categoryDto.Name }, categoryDto);  // Возвращаем статус 201 с ссылкой на созданный ресурс
        }

        // Обновить существующую категорию
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateCategoryDto categoryDto)
        {
            if (id != categoryDto.Id)
            {
                return BadRequest("Category ID mismatch.");
            }

            await _categoryService.UpdateAsync(categoryDto);
            return NoContent();  // Возвращаем статус 204 (успешное обновление, без контента)
        }

        // Удалить категорию
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _categoryService.DeleteAsync(id);
            return NoContent();  // Возвращаем статус 204 (успешное удаление, без контента)
        }
    }
}
