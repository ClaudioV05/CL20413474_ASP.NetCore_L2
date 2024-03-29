using Store.Management.Domain.Entities;

namespace Store.Management.Application.Interfaces
{
    /// <summary>
    /// Interface IServiceCategory.
    /// </summary>
    public interface IServiceCategory
    {
        /// <summary>
        /// Obtain all list of category.
        /// </summary>
        /// <returns>The list of category.</returns>
        IEnumerable<Category> ObtainAllListOfCategory();
    }
}