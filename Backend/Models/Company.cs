namespace Backend.Models;

public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }         
    public string Industry { get; set; }       
    public string Location { get; set; }       
    public string Description { get; set; }    
    public string? Logo { get; set; }          
    public string Color { get; set; }          
    public DateTime CreatedAt { get; set; }    
}
