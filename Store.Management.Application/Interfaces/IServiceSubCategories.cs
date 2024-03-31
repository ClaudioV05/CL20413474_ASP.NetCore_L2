using Store.Management.Domain.Entities;

namespace Store.Management.Application.Interfaces
{
    /// <summary>
    /// Interface IServiceSubCategories.
    /// </summary>
    public interface IServiceSubCategories
    {
        /// <summary>
        /// To obtain list of sub categories.
        /// </summary>
        /// <returns>The list of sub categories.</returns>
        Task<IEnumerable<SubCategories>> GetListOfSubCategories();

        /// <summary>
        /// To obtain the list of category by sub category id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<SubCategories>> GetTheListOfSubCategoryByCategoryId(int id);
    }
}