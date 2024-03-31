using Store.Management.Domain.Entities;

namespace Store.Management.Domain.Interfaces
{
    /// <summary>
    /// Interface IRepositorySubCategory
    /// </summary>
    public interface IRepositorySubCategory
    {
        /// <summary>
        /// To obtain list of sub category.
        /// </summary>
        /// <returns>The list of sub category.</returns>
        Task<IEnumerable<SubCategories>> GetListOfSubCategory();
    }
}