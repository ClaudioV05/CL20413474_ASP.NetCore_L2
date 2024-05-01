using Store.Management.Application.Interfaces;
using Store.Management.Domain.Entities;
using Store.Management.Domain.Interfaces;

namespace Store.Management.Application.Services;

public class ServiceProducts : IServiceProducts
{
    private readonly IRepositoryProducts _repositoryProducts;

    public ServiceProducts(IRepositoryProducts repositoryProducts)
    {
        _repositoryProducts = repositoryProducts;
    }

    public async Task<IEnumerable<Products>> GetTheListOfProducts()
    {
        try
        {
            var listItems = await _repositoryProducts.GetTheListOfProducts();

            return (from product
                    in listItems
                    where product.ProductID > 0
                    select product).ToList();
        }
        catch (Exception)
        {
            return Enumerable.Empty<Products>();
        }
    }

    public async Task<IEnumerable<Products>> GetTheListOfProductBySubCategoryId(int id)
    {
        try
        {
            var listItems = await _repositoryProducts.GetTheListOfProducts();

            return (from product
                    in listItems
                    where product.ProductID > 0
                    && product.SubCategoryID.Equals(id)
                    select product).ToList();
        }
        catch (Exception)
        {
            return Enumerable.Empty<Products>();
        }
    }
}