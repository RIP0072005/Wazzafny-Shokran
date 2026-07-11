using Backend.DTOs.Categories;

namespace Backend.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllAsync();
    Task<CategoryDto> CreateAsync(CreateCategoryDto dto);
    Task<CategoryDto> UpdateAsync(int id, CreateCategoryDto dto);
    Task DeleteAsync(int id);
}
