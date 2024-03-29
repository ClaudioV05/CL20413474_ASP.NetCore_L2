using Store.Management.Domain.Entities;

namespace Store.Management.Application.Interfaces
{
    /// <summary>
    /// Interface IServiceSubCategory.
    /// </summary>
    public interface IServiceSubCategory
    {
        /// <summary>
        /// Obtain all list of sub category.
        /// </summary>
        /// <returns>The list of sub category.</returns>
        IEnumerable<SubCategory> ObtainAllListOfSubCategory();

        /// <summary>
        /// Obtain all list of sub category by id.
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        IEnumerable<SubCategory> ObtainListOfSubCategoryById(int categoryID);
    }
}