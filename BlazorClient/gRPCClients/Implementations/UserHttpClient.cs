// using System.Net;
// using System.Text.Json;
// using Domain.Models;
// using HttpClients.Interfaces;
//
// namespace HttpClients.Implementations;
//
// public class UserHttpClient : IUserService
// {
//     
//     
//     private readonly HttpClient client;
//     public UserHttpClient(HttpClient client)
//     {
//         this.client = client;
//     }
//     public async Task<User> GetByUsernameAsync(string username)
//     {
//         var response = await client.GetAsync("http://localhost:8080/getUser/" + username );
//        
//         var result = await response.Content.ReadAsStringAsync();
//
//         if (!response.IsSuccessStatusCode) throw new Exception(result);
//
//         var user= JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions
//         {
//             PropertyNameCaseInsensitive = true
//         })!;
//         return user;
//     }
// }