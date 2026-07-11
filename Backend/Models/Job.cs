namespace Backend.Models;

public class Job
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? Skills { get; set; }
    public string Location { get; set; } = string.Empty;
    public string LocationType { get; set; } = "في الموقع";
    public decimal Salary { get; set; }
    public string Color { get; set; } = "#4F46E5";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int CompanyId { get; set; }
    public Company? Company { get; set; }

    public ICollection<JobCategory> Categories { get; set; } = new List<JobCategory>();
}
