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

        public IEnumerable<Product> GetTheListOfProduct()
        {
            try
            {
                var listOfProduct = _repositoryProduct.GetTheListOfProduct();

                return (from product
                        in listOfProduct
                        where product.ProductID > 0
                        select product).ToList();
            }
            catch (Exception)
            {
                return Enumerable.Empty<Product>();
            }
        }

        public IEnumerable<Product> GetTheListOfProductBySubCategoryId(int id)
        {
            try
            {
                var listOfProduct = _repositoryProduct.GetTheListOfProduct();

                return (from product
                        in listOfProduct
                        where product.ProductID > 0
                        && product.SubCategoryID.Equals(id)
                        select product).ToList();
            }
            catch (Exception)
            {
                return Enumerable.Empty<Product>();
            }
        }
    }
}