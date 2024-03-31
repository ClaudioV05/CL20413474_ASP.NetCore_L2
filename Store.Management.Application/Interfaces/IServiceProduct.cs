using Store.Management.Domain.Entities;

namespace Store.Management.Application.Interfaces
{
    /// <summary>
    /// Interface IServiceProduct.
    /// </summary>
    public interface IServiceProduct
    {
        /// <summary>
        /// To obtain the list of product.
        /// </summary>
        /// <returns>The list of product.</returns>
        Task<IEnumerable<Products>> GetTheListOfProduct();

        /// <summary>
        /// To obtain the list of product by sub category id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<Products>> GetTheListOfProductBySubCategoryId(int id);
    }
}