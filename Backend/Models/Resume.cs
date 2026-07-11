namespace Backend.Models;

public class Resume
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string JobTitle { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string? Summary { get; set; }
    public string? University { get; set; }
    public string? GraduationYear { get; set; }
    public string? Degree { get; set; }
    public string? Skills { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
