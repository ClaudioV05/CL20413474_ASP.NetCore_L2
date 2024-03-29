using Store.Management.Domain.Entities;

namespace Store.Management.Application.Interfaces
{
    /// <summary>
    /// Interface IServiceSubCategory.
    /// </summary>
    public interface IServiceSubCategory
    {
        /// <summary>
        /// To obtain list of sub category.
        /// </summary>
        /// <returns>The list of sub category.</returns>
        IEnumerable<SubCategory> GetListOfSubCategory();

        /// <summary>
        /// To obtain the list of category by sub category id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<SubCategory> GetTheListOfSubCategoryByCategoryId(int id);
    }
}