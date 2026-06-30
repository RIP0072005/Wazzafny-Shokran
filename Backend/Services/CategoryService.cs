using Backend.DTOs.Categories;
using Backend.Interfaces;
using Backend.Models;

namespace Backend.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepo;

    public CategoryService(ICategoryRepository categoryRepo)
    {
        _categoryRepo = categoryRepo;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllAsync()
    {
        var categories = await _categoryRepo.GetAllAsync();

        return categories.Select(c => new CategoryDto
        {
            Id = c.Id,
            Name = c.Name,
            NameAr = c.NameAr
        });
    }

    public async Task<CategoryDto> CreateAsync(CreateCategoryDto dto)
    {
        var category = new JobCategory
        {
            Name = dto.Name,
            NameAr = dto.NameAr
        };

        await _categoryRepo.AddAsync(category);
        await _categoryRepo.SaveAsync();

        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            NameAr = category.NameAr
        };
    }

    public async Task<CategoryDto> UpdateAsync(int id, CreateCategoryDto dto)
    {
        var category = await _categoryRepo.GetByIdAsync(id);
        if (category is null)
            throw new KeyNotFoundException($"Category with id {id} not found.");

        category.Name = dto.Name;
        category.NameAr = dto.NameAr;

        _categoryRepo.Update(category);
        await _categoryRepo.SaveAsync();

        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            NameAr = category.NameAr
        };
    }

    public async Task DeleteAsync(int id)
    {
        var category = await _categoryRepo.GetByIdAsync(id);
        if (category is null)
            throw new KeyNotFoundException($"Category with id {id} not found.");

        _categoryRepo.Delete(category);
        await _categoryRepo.SaveAsync();
    }
}
