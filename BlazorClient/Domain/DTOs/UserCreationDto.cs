namespace Domain.DTOs;

public class UserCreationDto
{   
    public string Name { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public bool IsAdmin { get; set; }
}