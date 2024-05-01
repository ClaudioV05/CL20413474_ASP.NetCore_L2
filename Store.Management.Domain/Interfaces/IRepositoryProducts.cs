using Store.Management.Domain.Entities;

namespace Store.Management.Domain.Interfaces;

/// <summary>
/// Interface IRepositoryProduct
/// </summary>
public interface IRepositoryProducts
{
    /// <summary>
    /// To obtain the list of products.
    /// </summary>
    /// <returns>The list of products.</returns>
    Task<IEnumerable<Products>> GetTheListOfProducts();
}