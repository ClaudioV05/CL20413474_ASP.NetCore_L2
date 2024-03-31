using Store.Management.Application.Interfaces;
using Store.Management.Domain.Entities;
using Store.Management.Domain.Interfaces;

namespace Store.Management.Application.Services
{
    public class ServiceSubCategories : IServiceSubCategories
    {
        private readonly IRepositorySubCategories _repositorySubCategories;

        public ServiceSubCategories(IRepositorySubCategories repositorySubCategories)
        {
            _repositorySubCategories = repositorySubCategories;
        }

        public async Task<IEnumerable<SubCategories>> GetListOfSubCategories()
        {
            try
            {
                var listItems = await _repositorySubCategories.GetListOfSubCategories();

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
                var listItems = await _repositorySubCategories.GetListOfSubCategories();

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