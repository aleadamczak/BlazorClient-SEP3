namespace BlazorClient.gRPCClients.Interfaces;

public interface IPrivateFileService
{
    Task<PrivateFile> CreateAsync(PrivateFileCreationDto file);

    Task<FileDownloadDto> GetAsync(Id id);

    Task<IEnumerable<PrivateFile>> GetAllAsync();
    
    Task<IEnumerable<FileDisplayDto>> GetAllDtosAsync();
}