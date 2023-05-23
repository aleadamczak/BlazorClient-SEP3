using BlazorClient.gRPCClients.Interfaces;
using Grpc.Net.Client;


namespace BlazorClient.gRPCClients.Implementations;

public class UsergRpcClient : IUserService
{
    
    private UserController.UserControllerClient _client;
    private User _loggedUser;
    
    public UsergRpcClient()
    {
    //     // Set the URL of the Java gRPC server
    var grpcServerUrl = "http://localhost:9090";
    //     
    //     // Create the gRPC channel
    var channel = GrpcChannel.ForAddress(grpcServerUrl);
    
        // Create the gRPC client
        _client = new UserController.UserControllerClient(channel);

        _loggedUser = null;
    }
    
    
    public async Task<User> GetByUsernameAsync(string username)
    {
        String usernameProto = new String()
        {
            String_ = username
        };

        return await Task.FromResult(_client.getByUsername(usernameProto));
    }
    
    public async Task<User> CreateAsync(UserCreationDto userCreationDto)
    {
        return await Task.FromResult(_client.create(userCreationDto));
    }

    public async Task<UserDisplayDtoList> GetAllAsync(Empty empty)
    {
        return await Task.FromResult(_client.getAllDisplay(empty));
    }

    public async Task<User> LoginAsync(UserLogInDto userLogInDto)
    {
        try
        {
            var newLoggedUser = await Task.FromResult(_client.logIn(userLogInDto));
            _loggedUser = newLoggedUser;
            return newLoggedUser;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
}