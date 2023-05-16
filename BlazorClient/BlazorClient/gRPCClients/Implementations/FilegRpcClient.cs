using BlazorClient.gRPCClients.Interfaces;
using Domain.DTOs;
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
        throw new NotImplementedException();
    }
    
  

    
}