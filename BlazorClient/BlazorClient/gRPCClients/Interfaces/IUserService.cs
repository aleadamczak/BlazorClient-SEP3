﻿

namespace BlazorClient.gRPCClients.Interfaces;

public interface IUserService
{

    Task<User> GetByUsernameAsync(string username);

}