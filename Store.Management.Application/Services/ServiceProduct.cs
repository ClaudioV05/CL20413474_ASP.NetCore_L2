using Store.Management.Application.Interfaces;
using Store.Management.Domain.Entities;
using Store.Management.Domain.Interfaces;

namespace Store.Management.Application.Services
{
    public class ServiceProduct : IServiceProduct
    {
        private readonly IRepositoryProduct _repositoryProduct;

        public ServiceProduct(IRepositoryProduct repositoryProduct)
        {
            _repositoryProduct = repositoryProduct;
        }

        public async Task<IEnumerable<Products>> GetTheListOfProduct()
        {
            try
            {
                var listItems = await _repositoryProduct.GetTheListOfProduct();

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
                var listItems = await _repositoryProduct.GetTheListOfProduct();

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
}