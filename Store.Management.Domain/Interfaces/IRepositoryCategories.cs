using Store.Management.Domain.Entities;

namespace Store.Management.Domain.Interfaces
{
    /// <summary>
    /// Interface IRepositoryCategories
    /// </summary>
    public interface IRepositoryCategories
    {
        /// <summary>
        /// To obtain the list of categories.
        /// </summary>
        /// <returns>The list of categories.</returns>
        Task<IEnumerable<Categories>> GetTheListOfCategories();
    }
}