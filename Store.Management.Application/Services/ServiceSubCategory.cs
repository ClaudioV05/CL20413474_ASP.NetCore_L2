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

        public async Task<IEnumerable<SubCategories>> GetListOfSubCategory()
        {
            try
            {
                var listItems = await _repositorySubCategory.GetListOfSubCategory();

                return (from subCategory
                        in listItems
                        where subCategory.CategoryID > 0
                        select subCategory).ToList();
            }
            catch (Exception)
            {
                return Enumerable.Empty<SubCategories>();
            }
        }

        public async Task<IEnumerable<SubCategories>> GetTheListOfSubCategoryByCategoryId(int id)
        {
            try
            {
                var listItems = await _repositorySubCategory.GetListOfSubCategory();

                return (from subCategory
                        in listItems
                        where subCategory.CategoryID > 0
                        && subCategory.CategoryID.Equals(id)
                        select subCategory).ToList();
            }
            catch (Exception)
            {
                return Enumerable.Empty<SubCategories>();
            }
        }
    }
}