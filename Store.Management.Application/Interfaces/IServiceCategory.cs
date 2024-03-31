using Store.Management.Domain.Entities;

namespace Store.Management.Application.Interfaces
{
    /// <summary>
    /// Interface IServiceCategory.
    /// </summary>
    public interface IServiceCategory
    {
        /// <summary>
        /// To obtain the list of category.
        /// </summary>
        /// <returns>The list of category.</returns>
       Task<IEnumerable<Categories>> GetTheListOfCategory();
    }
}