using Store.Management.Domain.Entities;

namespace Store.Management.Application.Interfaces
{
    /// <summary>
    /// Interface IServiceCategories.
    /// </summary>
    public interface IServiceCategories
    {
        /// <summary>
        /// To obtain the list of categories.
        /// </summary>
        /// <returns>The list of categories.</returns>
        Task<IEnumerable<Categories>> GetTheListOfCategories();
    }
}