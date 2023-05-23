using BlazorClient.gRPCClients.Interfaces;
using Grpc.Net.Client;

namespace BlazorClient.gRPCClients.Implementations;

public class PrivateFilegRpcClient : IPrivateFileService
{
    private PrivateFileController.PrivateFileControllerClient _client;
    
    public PrivateFilegRpcClient()
    {
        //     // Set the URL of the Java gRPC server
        var grpcServerUrl = "http://localhost:9090";
        //     
        //     // Create the gRPC channel
        var channel = GrpcChannel.ForAddress(grpcServerUrl);
    
        // Create the gRPC client
        _client = new PrivateFileController.PrivateFileControllerClient(channel);
    }


    public Task<PrivateFile> CreateAsync(PrivateFileCreationDto file)
    {
        return Task.FromResult(_client.upload(file));
    }

    public Task<FileDownloadDto> GetAsync(Id id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PrivateFile>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<FileDisplayDto>> GetAllDtosAsync()
    {
        throw new NotImplementedException();
    }
}