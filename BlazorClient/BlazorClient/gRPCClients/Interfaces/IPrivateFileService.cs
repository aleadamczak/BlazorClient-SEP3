namespace BlazorClient.gRPCClients.Interfaces;

public interface IPrivateFileService
{
    Task<PrivateFile> CreateAsync(PrivateFileCreationDto file);

    Task<FileDownloadDto> GetAsync(Id id);

    Task<PrivateFileDisplayDtoList> GetSharedWith(User user);
    
    Task<IEnumerable<FileDisplayDto>> GetAllDtosAsync();
    void Delete(int id);
}