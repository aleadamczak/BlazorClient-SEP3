using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorClient.Auth;

public static class AuthorizationPolicies
{
    public static void AddPolicies(IServiceCollection services)
    {
        services.AddAuthorizationCore(options =>
        {
            options.AddPolicy("MustBeAdmin", a =>
                a.RequireAuthenticatedUser().RequireClaim("isAdmin", "true"));
            options.AddPolicy("LoggedUsersOnly", policy =>
                policy.RequireAuthenticatedUser());
        });
    }
}