

namespace BlazorClient.gRPCClients.Interfaces;

public interface IFileService
{

    Task<File> CreateAsync(FileCreationDto file);

    Task<File> GetAsync(Id id);

    Task<IEnumerable<File>> GetAllAsync();

}