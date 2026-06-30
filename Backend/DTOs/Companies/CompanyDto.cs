using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs.Companies;

public class CompanyDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Industry { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? Logo { get; set; }
    public string Color { get; set; } = string.Empty;
    public int OpenJobsCount { get; set; }
}

public class CreateCompanyDto
{
    [Required] public string Name { get; set; } = string.Empty;
    [Required] public string Industry { get; set; } = string.Empty;
    [Required] public string Location { get; set; } = string.Empty;
    [Required] public string Description { get; set; } = string.Empty;
    public string? Logo { get; set; }
    public string Color { get; set; } = "#4F46E5";
}
