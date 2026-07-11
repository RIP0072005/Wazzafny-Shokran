using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs.Applications;

public class ApplicationDto
{
    public int Id { get; set; }
    public int JobId { get; set; }
    public string JobTitle { get; set; } = string.Empty;
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}

public class CreateApplicationDto
{
    [Required] public int JobId { get; set; }
    [Required] public int UserId { get; set; }
}

public class UpdateApplicationStatusDto
{
    [Required] public string Status { get; set; } = string.Empty;
}
