namespace BlazorClient.gRPCClients.Interfaces;

public interface ICategoryService
{
    Task<Domain.Models.Category> CreateAsync(Domain.Models.Category category);

    Task<CategoryList> GetAllAsync(Empty empty);
}