using Grpc.Core;

namespace BlazorClient.gRPCClients.Interfaces;

public interface ICategoryService
{


    Task<CategoryList> GetAllAsync(Empty empty);
    Task<Category> CreateAsync(Category category);
    Task<Empty> DeleteAsync(Category category);
}