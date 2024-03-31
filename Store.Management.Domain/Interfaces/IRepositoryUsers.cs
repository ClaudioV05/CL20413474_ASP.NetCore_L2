using Store.Management.Domain.Entities;

namespace Store.Management.Domain.Interfaces
{
    /// <summary>
    /// Interface IRepositoryUser
    /// </summary>
    public interface IRepositoryUsers
    {
        /// <summary>
        /// Register a new user through identity.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task RegisterUser(User user);
    }
}