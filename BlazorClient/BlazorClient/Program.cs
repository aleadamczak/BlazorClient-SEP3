using System.Text;
using BlazorClient.Auth;
using BlazorClient.gRPCClients.Implementations;
using BlazorClient.gRPCClients.Interfaces;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IUserService, UsergRpcClient>();
builder.Services.AddScoped<IFileService, FilegRpcClient>();
builder.Services.AddScoped<ICategoryService, CategorygRpcClient>();
builder.Services.AddScoped<IPrivateFileService, PrivateFilegRpcClient>();

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
builder.Services.AddScoped<IAuthService, JwtAuthService>();



AuthorizationPolicies.AddPolicies(builder.Services);
builder.Services.AddAuthorizationCore();

builder.Services.AddSingleton(services =>
{
    var backendUrl = "http://localhost:9090"; // Replace with your gRPC server URL
    return GrpcChannel.ForAddress(backendUrl);
});
    
//     builder.Services.AddSingleton<UsergRpcClient>(services =>
//     {
//         var backendUrl = "http://localhost:9090";
//         var channel = GrpcChannel.ForAddress(backendUrl);
//         return new UsergRpcClient(channel);
//     });
//
// builder.Services.AddSingleton<FilegRpcClient>(services =>
// {
//     var backendUrl = "http://localhost:9090";
//     var channel = GrpcChannel.ForAddress(backendUrl);
//     return new FilegRpcClient(channel);
// });



//


// builder.Services.AddScoped(sp =>
// {
//     var channel = GrpcChannel.ForAddress("http://localhost:9090");
//     
//
//     return new UsergRpcClient(channel);
// });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}




app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");


app.Run();