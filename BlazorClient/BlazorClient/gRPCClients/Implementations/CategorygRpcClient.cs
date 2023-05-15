using BlazorClient.gRPCClients.Interfaces;

namespace BlazorClient.gRPCClients.Implementations;

public class CategorygRpcClient : ICategoryService
{
    public Task<Domain.Models.Category> CreateAsync(Domain.Models.Category category)
    {
        throw new NotImplementedException();
    }
    
}