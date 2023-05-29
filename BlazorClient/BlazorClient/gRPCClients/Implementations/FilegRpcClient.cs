using BlazorClient.gRPCClients.Interfaces;
using Grpc.Net.Client;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;


namespace BlazorClient.gRPCClients.Implementations;

public class FilegRpcClient : IFileService {
    
    private FileController.FileControllerClient _client;
    
    public FilegRpcClient()
    {
        // // Set the URL of the Java gRPC server
        var grpcServerUrl = "http://localhost:9090";
        //
        // // Create the gRPC channel
        var channel = GrpcChannel.ForAddress(grpcServerUrl);
    
        // Create the gRPC client
        _client = new FileController.FileControllerClient(channel);
        
    }
    public async Task<File> CreateAsync(FileCreationDto file)
    {
        return await Task.FromResult(_client.upload(file));

    }

    public async Task<FileDownloadDto> GetAsync(Id id)
    {
        try
        {
            return await Task.FromResult(_client.download(id));
        }
        catch (RpcException e)
        {
            if (e.Status.StatusCode == StatusCode.Internal)
            {
                NullException exception = e.Trailers
                    .OfType<NullException>()
                    .FirstOrDefault();
                throw new Exception(exception.Message);
            }
            throw new Exception(e.Message);
        }
    }

    public Task<IEnumerable<File>> GetAllAsync()
    {
        return null;
    }
    
    private IEnumerable<FileDisplayDto> ConvertToDtoList(FileDisplayList fileDisplayList)
    {
        List<FileDisplayDto> dtoList = new List<FileDisplayDto>();
        foreach (var fileDisplay in fileDisplayList.Files)
        {
            FileDisplayDto dto = new FileDisplayDto
            {
                Title = fileDisplay.Title,
                Description = fileDisplay.Description,
                Category = fileDisplay.Category,
                Id = fileDisplay.Id,
                UploadedBy = fileDisplay.UploadedBy
            };
            dtoList.Add(dto);
        }
        return dtoList;
    }
    
    public async Task<IEnumerable<FileDisplayDto>> GetAllDtosAsync()
    {
        FileDisplayList fileDisplayList = await _client.getAllAsync(new Empty());
        
        List<FileDisplayDto> dtoList = new List<FileDisplayDto>();
        foreach (var fileDisplay in fileDisplayList.Files)
        {
            FileDisplayDto dto = new FileDisplayDto
            {
                Title = fileDisplay.Title,
                Description = fileDisplay.Description,
                Category = fileDisplay.Category,
                Id = fileDisplay.Id,
                UploadedBy = fileDisplay.UploadedBy,
                ContentType = fileDisplay.ContentType
            };
            dtoList.Add(dto);
        }
        
        return dtoList;
    }

    public  void Delete(int id)
    {
        Id number = new Id()
        {
            Id_ = id
        };
       _client.remove(number);
    }
    
    public async Task<File> ChangeCategoryAsync(FileUpdateDto file)

    {
        return await Task.FromResult(_client.update(file));

    }





}