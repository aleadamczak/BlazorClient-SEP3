using System.Security.Claims;
using System.Text.Json;

namespace BlazorClient.Auth;

public class JwtAuthService : IAuthService
{

    // this private variable for simple caching
    public static string? Jwt { get; set; } = "";

    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; } = null!;

    public static ClaimsPrincipal CreateClaimsPrincipal()
    {
        if (string.IsNullOrEmpty(Jwt))
        {
            return new ClaimsPrincipal();
        }

        IEnumerable<Claim> claims = ParseClaimsFromJwt(Jwt);
        
        ClaimsIdentity identity = new(claims, "jwt");

        ClaimsPrincipal principal = new(identity);
        return principal;
    }

    public Task LogoutAsync()
    {
        Jwt = null;
        ClaimsPrincipal principal = new();
        OnAuthStateChanged?.Invoke(principal);
        return Task.CompletedTask;
    }

    public Task<ClaimsPrincipal> GetAuthAsync()
    {
        ClaimsPrincipal principal = CreateClaimsPrincipal();
        return Task.FromResult(principal);
    }

    public async Task<User> getAuthenticatedUserObject()
    {
        var principal = await GetAuthAsync();
        var userIdClaim = principal.FindFirst("id")?.Value;
        var usernameClaim = principal.FindFirst("username")?.Value;
        var nameClaim = principal.FindFirst("name")?.Value;
        var passwordClaim = principal.FindFirst("password")?.Value;
        var isAdminClaim = principal.FindFirst("isAdmin")?.Value;

        if (userIdClaim != null && int.TryParse(userIdClaim, out int userId) &&
            usernameClaim != null && nameClaim != null &&
            passwordClaim != null && isAdminClaim != null && bool.TryParse(isAdminClaim, out bool isAdmin))
        {
            var user = new User
            {
                Id = userId,
                Username = usernameClaim,
                Name = nameClaim,
                Password = passwordClaim,
                IsAdmin = isAdmin
            };
            Console.WriteLine(user.Name);
            return user;
            
        }

        return new User();
    }
    
    public async Task<string> getAuthenticatedUsername()
    {
        var principal = await GetAuthAsync();
        var usernameClaim = principal.FindFirst("username")?.Value;

        if (usernameClaim != null)
        {
            return usernameClaim;
        }
        return new string("");
    }

    
    private static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
    {
        string payload = jwt.Split('.')[1];
        byte[] jsonBytes = ParseBase64WithoutPadding(payload);
        Dictionary<string, object>? keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);
        return keyValuePairs!.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()!));
    }

    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2:
                base64 += "==";
                break;
            case 3:
                base64 += "=";
                break;
        }

        return Convert.FromBase64String(base64);
    }
}