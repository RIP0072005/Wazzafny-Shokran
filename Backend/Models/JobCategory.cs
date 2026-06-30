namespace Backend.Models;

public class JobCategory
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string NameAr { get; set; } = string.Empty;

    public ICollection<Job> Jobs { get; set; } = new List<Job>();
}
