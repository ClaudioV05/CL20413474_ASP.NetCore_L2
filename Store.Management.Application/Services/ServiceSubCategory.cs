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

        public IEnumerable<SubCategory> ObtainAllListOfSubCategory()
        {
            try
            {
                var listOfSubCategory = _repositorySubCategory.ObtainAllListOfSubCategory();
                return (from subCategory
                        in listOfSubCategory
                        where subCategory.CategoryID > 0
                        select subCategory).ToList();
            }
            catch (Exception)
            {
                return new List<SubCategory>();
            }
        }

        public IEnumerable<SubCategory> ObtainListOfSubCategoryById(int categoryID)
        {
            try
            {
                var listOfSubCategory = _repositorySubCategory.ObtainAllListOfSubCategory();

                return (from subCategory
                        in listOfSubCategory
                        where subCategory.CategoryID > 0
                        && subCategory.CategoryID.Equals(categoryID)
                        select subCategory).ToList();
            }
            catch (Exception)
            {
                return new List<SubCategory>();
            }
        }
    }
}