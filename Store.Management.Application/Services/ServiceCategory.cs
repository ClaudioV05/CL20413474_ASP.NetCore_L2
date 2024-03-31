using Store.Management.Application.Interfaces;
using Store.Management.Domain.Entities;
using Store.Management.Domain.Interfaces;

namespace Store.Management.Application.Services
{
    public class ServiceCategory : IServiceCategory
    {
        private readonly IRepositoryCategory _repositoryCategory;

        public ServiceCategory(IRepositoryCategory repositoryCategory)
        {
            _repositoryCategory = repositoryCategory;
        }

        public async Task<IEnumerable<Categories>> GetTheListOfCategory()
        {
            try
            {
                var listItems = await _repositoryCategory.GetTheListOfCategory();

                return (from category
                        in listItems
                        where category.CategoryID > 0
                        select category).ToList();
            }
            catch (Exception)
            {
                return Enumerable.Empty<Categories>();
            }
        }
    }
}