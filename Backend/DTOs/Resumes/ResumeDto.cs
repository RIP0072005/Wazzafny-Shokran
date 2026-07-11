using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs.Resumes;

public class ResumeDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string JobTitle { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string? Summary { get; set; }
    public string? University { get; set; }
    public string? GraduationYear { get; set; }
    public string? Degree { get; set; }
    public string? Skills { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public class CreateResumeDto
{
    [Required] public int UserId { get; set; }
    [Required] public string FullName { get; set; } = string.Empty;
    [Required] public string JobTitle { get; set; } = string.Empty;
    [Required] public string Email { get; set; } = string.Empty;
    [Required] public string Phone { get; set; } = string.Empty;
    public string? Summary { get; set; }
    public string? University { get; set; }
    public string? GraduationYear { get; set; }
    public string? Degree { get; set; }
    public string? Skills { get; set; }
}

public class UpdateResumeDto
{
    [Required] public string FullName { get; set; } = string.Empty;
    [Required] public string JobTitle { get; set; } = string.Empty;
    [Required] public string Email { get; set; } = string.Empty;
    [Required] public string Phone { get; set; } = string.Empty;
    public string? Summary { get; set; }
    public string? University { get; set; }
    public string? GraduationYear { get; set; }
    public string? Degree { get; set; }
    public string? Skills { get; set; }
}
