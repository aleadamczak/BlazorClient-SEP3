using Domain.Models;

namespace Domain.DTOs;

public class FileDisplayDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public int Id { get; set; }
    public User? UploadedBy { get; set; }
    public string ContentType { get; set; }
}