

namespace BlazorClient.gRPCClients.Interfaces;

public interface IUserService
{

    Task<User> GetByUsernameAsync(string username);
    
    Task<User> CreateAsync(UserCreationDto userCreationDto);

    Task<UserTokenDto> LoginAsync(UserLogInDto userLogInDto);

    Task<UserDisplayDtoList> GetAllAsync(Empty empty);

}