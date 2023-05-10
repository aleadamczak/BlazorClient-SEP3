using Domain.Models;

namespace Domain.DTOs;

public class FileCreationDto
{
    public User UploadedBy{ get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public byte[] Bytes { get; set; }
    
}