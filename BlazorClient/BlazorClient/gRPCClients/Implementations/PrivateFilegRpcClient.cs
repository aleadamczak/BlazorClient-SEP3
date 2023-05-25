using BlazorClient.gRPCClients.Interfaces;
using Grpc.Core;
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


    public async Task<PrivateFile> CreateAsync(PrivateFileCreationDto file)
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

    public async Task<PrivateFileDisplayDtoList> GetSharedWith(User user)
    {
        return await Task.FromResult(_client.getSharedWith(user));
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