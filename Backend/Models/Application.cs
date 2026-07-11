namespace Backend.Models;

public class Application
{
    public int Id { get; set; }
    public int JobId { get; set; }
    public Job? Job { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public string Status { get; set; } = "قيد المراجعة";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
