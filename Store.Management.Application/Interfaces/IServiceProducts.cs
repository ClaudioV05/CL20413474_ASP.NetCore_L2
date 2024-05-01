using Store.Management.Domain.Entities;

namespace Store.Management.Application.Interfaces;

/// <summary>
/// Interface IServiceProducts.
/// </summary>
public interface IServiceProducts
{
    /// <summary>
    /// To obtain the list of products.
    /// </summary>
    /// <returns>The list of products.</returns>
    Task<IEnumerable<Products>> GetTheListOfProducts();

    /// <summary>
    /// To obtain the list of product by sub category id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<IEnumerable<Products>> GetTheListOfProductBySubCategoryId(int id);
}