using System.Security.Claims;

namespace BlazorClient.Auth;

public interface IAuthService
{
    public Task<User> getAuthenticatedUserObject();
    public Task<string> getAuthenticatedUsername();
    public Task LogoutAsync();
    public Task<ClaimsPrincipal> GetAuthAsync();
    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
}