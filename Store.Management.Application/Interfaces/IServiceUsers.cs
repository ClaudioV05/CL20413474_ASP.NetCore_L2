using Store.Management.Domain.Entities;

namespace Store.Management.Application.Interfaces;

/// <summary>
/// Interface IServiceUsers.
/// </summary>
public interface IServiceUsers
{
    /// <summary>
    /// Register a new user through identity.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task RegisterUser(User user);

    /// <summary>
    /// Login user.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task LoginUser(User user);
}