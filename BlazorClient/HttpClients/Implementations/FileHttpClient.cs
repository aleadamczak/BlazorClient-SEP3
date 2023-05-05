using System.Net.Http.Json;
using System.Text.Json;
using HttpClients.Interfaces;
using File = Domain.Models.File;

namespace HttpClients.Implementations;

public class FileHttpClient : IFileService
{
    private readonly HttpClient client;
    public FileHttpClient(HttpClient client)
    {
        this.client = client;
    }
    
    public async Task<File> CreateAsync(File file)
    {
        Console.WriteLine("file sent to the java server");
        var response = await client.PostAsJsonAsync("http://localhost:8080/uploadFile", file);
       
        var result = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode) throw new Exception(result);

        var newFile= JsonSerializer.Deserialize<File>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return newFile;
    }

    public async Task<File> GetAsync(int id)
    {
        var response = await client.GetAsync("http://localhost:8080/downloadFile/{id}");
        var result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode) throw new Exception(result);

        var newFile= JsonSerializer.Deserialize<File>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return newFile;
    }
}