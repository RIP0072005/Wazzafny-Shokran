using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs.Jobs;

public class JobDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? Skills { get; set; }
    public string Location { get; set; } = string.Empty;
    public string LocationType { get; set; } = string.Empty;
    public decimal Salary { get; set; }
    public string Color { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public List<string> CategoryNames { get; set; } = new();
}

public class CreateJobDto
{
    [Required] public string Title { get; set; } = string.Empty;
    [Required] public string Description { get; set; } = string.Empty;
    public string? Skills { get; set; }
    [Required] public string Location { get; set; } = string.Empty;
    [Required] public string LocationType { get; set; } = "في الموقع";
    [Required] public decimal Salary { get; set; }
    public string Color { get; set; } = "#4F46E5";
    [Required] public int CompanyId { get; set; }
    [Required] public List<int> CategoryIds { get; set; } = new();
}

public class JobFilterDto
{
    public string? Search { get; set; }
    public List<int>? CategoryIds { get; set; }
    public string? LocationType { get; set; }
    public int? CompanyId { get; set; }
    public decimal? MinSalary { get; set; }
    public decimal? MaxSalary { get; set; }
}
