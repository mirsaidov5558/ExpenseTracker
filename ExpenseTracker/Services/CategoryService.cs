using ExpenseTracker.DTOs.CategoryDtos;
using ExpenseTracker.Exception;
using ExpenseTracker.Interfaces.Repositories;
using ExpenseTracker.Interfaces.Services;
using ExpenseTracker.Models;
using System;

public class CategoryService : ICategoryService
{
    public readonly ICategoryRepository _categoryRepository;
    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task AddAsync(CreateCategoryDto categoryDto)
    {
        var category = new Category
        {
            Name = categoryDto.Name,
        };
        await _categoryRepository.AddAsync(category);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _categoryRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<CategoryDto>> GetAllAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();
        var categoryDtos = new List<CategoryDto>();
        foreach (var categoryDto in categories)
        {
            categoryDtos.Add(new CategoryDto { Id = categoryDto.Id, Name = categoryDto.Name });

        }
        return categoryDtos;
    }

    public async Task<CategoryDto> GetByIdAsync(Guid Id)
    {
        var category = await _categoryRepository.GetByIdAsync(Id);
        if (category != null)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }
        return null;
    }

    public async Task UpdateAsync(UpdateCategoryDto categoryDto)
    {
        var category = new Category
        {
            Id = categoryDto.Id,
            Name = categoryDto.Name
        };
        await _categoryRepository.UpdateAsync(category);
    }
}
