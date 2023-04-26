namespace Domain.Models;

public class File
{
    public User UploadedByUser { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
}