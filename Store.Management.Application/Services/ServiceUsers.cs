using Store.Management.Application.Interfaces;
using Store.Management.Domain.Entities;
using Store.Management.Domain.Interfaces;

namespace Store.Management.Application.Services;

public class ServiceUsers : IServiceUsers
{
    private readonly IRepositoryUsers _repositoryUsers;

    public ServiceUsers(IRepositoryUsers repositoryUsers)
    {
        _repositoryUsers = repositoryUsers;
    }

    public async Task RegisterUser(User user)
    {
        try
        {
            await _repositoryUsers.RegisterUser(user);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task LoginUser(User user)
    {
        try
        {
            await _repositoryUsers.LoginUser(user);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}