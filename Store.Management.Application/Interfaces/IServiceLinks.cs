using Store.Management.Domain.Entities;

namespace Store.Management.Application.Interfaces
{
    /// <summary>
    /// Interface IServiceLinks.
    /// </summary>
    public interface IServiceLinks
    {
        /// <summary>
        /// Return the store management uri from Api.
        /// </summary>
        /// <returns></returns>
        string? ReturnStoreManagementUriApi();

        /// <summary>
        /// Return the store management name of controller.
        /// </summary>
        /// <returns></returns>
        string? ReturnStoreManagementNameController();

        /// <summary>
        /// Return the store management action name get the list of category.
        /// </summary>
        /// <returns></returns>
        string? ReturnStoreManagementActionNameGetTheListOfCategory();

        /// <summary>
        /// Return the store management action name get the list of sub category by category id.
        /// </summary>
        /// <returns></returns>
        string? ReturnStoreManagementActionNameGetTheListOfSubCategoryByCategoryId();

        /// <summary>
        /// Return the store management action name get the list of product by subcategory id.
        /// </summary>
        /// <returns></returns>
        string? ReturnStoreManagementActionNameGetTheListOfProductBySubCategoryId();

        /// <summary>
        /// To obtain the list of object category.
        /// </summary>
        /// <param name="uri"></param>
        /// <returns>The list from object category</returns>
        List<Category> GetTheListOfCategory(string uri);

        /// <summary>
        /// To obtain the list of object sub category.
        /// </summary>
        /// <param name="uri"></param>
        /// <returns>The list from object sub category</returns>
        List<SubCategory> LoadObjectSubCategoryById(string uri);

        /// <summary>
        /// To obtain the list of product by sub category id.
        /// </summary>
        /// <param name="uri"></param>
        /// <returns>he list from object product</returns>
        List<Product> GetTheListOfProductBySubCategoryId(string uri);
    }
}