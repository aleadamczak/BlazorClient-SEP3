

namespace BlazorClient.gRPCClients.Interfaces;

public interface IFileService
{

    Task<File> CreateAsync(FileCreationDto file);

    Task<FileDownloadDto> GetAsync(Id id);

    Task<IEnumerable<File>> GetAllAsync();

}