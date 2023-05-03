using Microsoft.AspNetCore.Components.Forms;

namespace Domain.Models;

public class File
{
    public User UploadedByUser { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public string Category { get; set; }

    // public IBrowserFile UploadedFile { get; set; }
    public byte[] Bytes { get; set; }
}