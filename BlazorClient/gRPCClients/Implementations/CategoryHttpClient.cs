// using System.Net.Http.Json;
// using System.Text.Json;
// using Domain.Models;
// using HttpClients.Interfaces;
// using File = System.IO.File;
//
// namespace HttpClients.Implementations;
//
// public class CategoryHttpClient : ICategoryService
// {
//     private readonly HttpClient client;
//     private ICategoryService _categoryServiceImplementation;
//
//     public CategoryHttpClient(HttpClient client)
//     {
//         this.client = client;
//     }
//     
//     public async Task<Category> CreateAsync(Category category)
//     {
//         Console.WriteLine("category sent to the java server");
//         var response = await client.PostAsJsonAsync("http://localhost:8080/uploadCategory", category);
//
//         var result = await response.Content.ReadAsStringAsync();
//
//         if (!response.IsSuccessStatusCode) throw new Exception(result);
//
//         var newcategory = JsonSerializer.Deserialize<Category>(result, new JsonSerializerOptions
//         {
//             PropertyNameCaseInsensitive = true
//         })!;
//
//         return newcategory;
//
//     }
// }