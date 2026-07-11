using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs.Categories;

public class CreateCategoryDto
{
    [Required] public string Name { get; set; } = string.Empty;
    [Required] public string NameAr { get; set; } = string.Empty;
}
