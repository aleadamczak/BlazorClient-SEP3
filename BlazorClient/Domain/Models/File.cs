using System.Net;
using Microsoft.AspNetCore.Components.Forms;

namespace Domain.Models;

public class File
{
    public int Id { get; set; }
    public User? UploadedByUser { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public string Category { get; set; }

    // public IBrowserFile UploadedFile { get; set; }
    public byte[] Bytes { get; set; }

    public File(int id, string title, string description, string category, User uploadedByUser, byte[] bytes)
    {
        Id = id;
        Title = title;
        Description = description;
        Category = category;
        UploadedByUser = uploadedByUser;
        Bytes = bytes;
    }
    
    public File(string title, string description, string category)
    {
        Title = title;
        Description = description;
        Category = category;
        Bytes = Array.Empty<byte>();
    }

    public File()
    {
        
    }
}