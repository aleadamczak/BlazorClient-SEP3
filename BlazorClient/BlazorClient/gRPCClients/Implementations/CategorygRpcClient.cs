using BlazorClient.gRPCClients.Interfaces;
using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc.ModelBinding;


namespace BlazorClient.gRPCClients.Implementations;

public class CategorygRpcClient : ICategoryService
{

    private CategoryController.CategoryControllerClient _client;
    public CategorygRpcClient()

    {
        // // Set the URL of the Java gRPC server
        var grpcServerUrl = "http://localhost:9090";
        //
        // // Create the gRPC channel
        var channel = GrpcChannel.ForAddress(grpcServerUrl);
    
        // Create the gRPC client
        _client = new CategoryController.CategoryControllerClient(channel);
        
    }
    public async Task<Category> CreateAsync(Category category)
    {
        return await Task.FromResult(_client.addCategory(category));

    }
    public async Task<Empty> DeleteAsync(Category category)
    {
        return await Task.FromResult(_client.removeCategory(category));
        
    }

    public Task<CategoryList> GetAllAsync(Empty empty)
    {
        return Task.FromResult(_client.getAll(empty));
    }
}