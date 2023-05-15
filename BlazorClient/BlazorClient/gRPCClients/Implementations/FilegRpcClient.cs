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

    public Task<File> GetAsync(Id id)
    {
        return Task.FromResult(_client.getById(id));
    }

    public Task<IEnumerable<File>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
    
  

    
}