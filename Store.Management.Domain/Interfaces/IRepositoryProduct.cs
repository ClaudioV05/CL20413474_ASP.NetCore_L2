using Store.Management.Domain.Entities;

namespace Store.Management.Domain.Interfaces
{
    /// <summary>
    /// Interface IRepositoryProduct
    /// </summary>
    public interface IRepositoryProduct
    {
        /// <summary>
        /// To obtain the list of product.
        /// </summary>
        /// <returns>The list of product.</returns>
        Task<IEnumerable<Product>> GetTheListOfProduct();
    }
}