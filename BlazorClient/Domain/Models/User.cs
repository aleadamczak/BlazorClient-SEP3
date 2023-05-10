namespace Domain.Models;

public class User
{
    public int? Id { get; set; }
    public bool IsAdmin { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    
}