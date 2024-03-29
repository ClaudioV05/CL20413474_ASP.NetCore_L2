using Store.Management.Domain.Entities;

namespace Store.Management.Domain.Interfaces
{
    /// <summary>
    /// Interface IRepositoryCategory
    /// </summary>
    public interface IRepositoryCategory
    {
        /// <summary>
        /// Obtain all list of category.
        /// </summary>
        /// <returns>The list of category.</returns>
        List<Category> ObtainAllListOfCategory();
    }
}