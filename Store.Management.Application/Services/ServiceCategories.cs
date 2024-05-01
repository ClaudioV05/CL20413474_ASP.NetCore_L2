using Store.Management.Application.Interfaces;
using Store.Management.Domain.Entities;
using Store.Management.Domain.Interfaces;

namespace Store.Management.Application.Services;

public class ServiceCategories : IServiceCategories
{
    private readonly IRepositoryCategories _repositoryCategories;

    public ServiceCategories(IRepositoryCategories repositoryCategories)
    {
        _repositoryCategories = repositoryCategories;
    }

    public async Task<IEnumerable<Categories>> GetTheListOfCategories()
    {
        try
        {
            var listItems = await _repositoryCategories.GetTheListOfCategories();

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