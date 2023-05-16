using BlazorClient.gRPCClients.Interfaces;
using Grpc.Net.Client;

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
    public Task<Domain.Models.Category> CreateAsync(Domain.Models.Category category)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryList> GetAllAsync(Empty empty)
    {
        return Task.FromResult(_client.getAll(empty));
    }
}