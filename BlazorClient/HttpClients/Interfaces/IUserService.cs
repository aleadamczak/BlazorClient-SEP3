using Domain.Models;

namespace HttpClients.Interfaces;

public interface IUserService
{

    Task<User> GetByUsernameAsync(string username);

}