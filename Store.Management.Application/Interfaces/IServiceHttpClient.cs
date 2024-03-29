using Store.Management.Domain.Entities;

namespace Store.Management.Application.Interfaces
{
    /// <summary>
    /// Interface IServiceHttpClient.
    /// </summary>
    public interface IServiceHttpClient
    {
        /// <summary>
        /// Load the list of object category.
        /// </summary>
        /// <param name="uri"></param>
        /// <returns>The list from object category</returns>
        List<Category> LoadObjectCategory(string uri);
    }
}