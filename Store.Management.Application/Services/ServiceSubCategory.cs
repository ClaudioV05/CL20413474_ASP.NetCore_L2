using Store.Management.Application.Interfaces;
using Store.Management.Domain.Entities;
using Store.Management.Domain.Interfaces;

namespace Store.Management.Application.Services
{
    public class ServiceSubCategory : IServiceSubCategory
    {
        private readonly IRepositorySubCategory _repositorySubCategory;

        public ServiceSubCategory(IRepositorySubCategory repositorySubCategory)
        {
            _repositorySubCategory = repositorySubCategory;
        }

        public IEnumerable<SubCategory> GetListOfSubCategory()
        {
            try
            {
                var listOfSubCategory = _repositorySubCategory.GetListOfSubCategory();

                return (from subCategory
                        in listOfSubCategory
                        where subCategory.CategoryID > 0
                        select subCategory).ToList();
            }
            catch (Exception)
            {
                return Enumerable.Empty<SubCategory>();
            }
        }

        public IEnumerable<SubCategory> GetTheListOfSubCategoryByCategoryId(int id)
        {
            try
            {
                var listOfSubCategory = _repositorySubCategory.GetListOfSubCategory();

                return (from subCategory
                        in listOfSubCategory
                        where subCategory.CategoryID > 0
                        && subCategory.CategoryID.Equals(id)
                        select subCategory).ToList();
            }
            catch (Exception)
            {
                return Enumerable.Empty<SubCategory>();
            }
        }
    }
}