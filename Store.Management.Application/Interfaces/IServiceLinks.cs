using Store.Management.Domain.Entities;

namespace Store.Management.Application.Interfaces
{
    /// <summary>
    /// Interface IServiceLinks.
    /// </summary>
    public interface IServiceLinks
    {
        #region Configuration.

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
        /// Return the store management action name login user.
        /// </summary>
        /// <returns></returns>
        string? ReturnStoreManagementActionNameLoginUser();

        /// <summary>
        /// Return the store management action name registration user.
        /// </summary>
        /// <returns></returns>
        string? ReturnStoreManagementActionNameRegistrationUser();

        #endregion Configuration.

        #region Store management products.

        /// <summary>
        /// To obtain the list of object categories.
        /// </summary>
        /// <param name="uri"></param>
        /// <returns>The list from object categories</returns>
        List<Categories> GetTheListOfCategories(string uri);

        /// <summary>
        /// To obtain the list of object sub category.
        /// </summary>
        /// <param name="uri"></param>
        /// <returns>The list from object sub category</returns>
        List<SubCategories> GetTheListOfSubCategoryByCategoryId(string uri);

        /// <summary>
        /// To obtain the list of product by sub category id.
        /// </summary>
        /// <param name="uri"></param>
        /// <returns>he list from object product</returns>
        List<Products> GetTheListOfProductBySubCategoryId(string uri);

        #endregion Store management products.

        #region Store management login user.

        /// <summary>
        /// Login User.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        User LoginUser(string uri, User user);

        #endregion Store management login user.

        #region Store management registration user.

        /// <summary>
        /// Register User.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="user"></param>
        /// <returns>The new User.</returns>
        void RegisterUser(string uri, User user);

        #endregion Store management registration user.
    }
}