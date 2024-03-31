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
       Task<IEnumerable<SubCategories>> GetListOfSubCategory();

        /// <summary>
        /// To obtain the list of category by sub category id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<SubCategories>> GetTheListOfSubCategoryByCategoryId(int id);
    }
}