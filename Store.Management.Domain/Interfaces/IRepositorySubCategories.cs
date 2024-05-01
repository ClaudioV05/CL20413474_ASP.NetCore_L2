using Store.Management.Domain.Entities;

namespace Store.Management.Domain.Interfaces;

/// <summary>
/// Interface IRepositorySubCategories
/// </summary>
public interface IRepositorySubCategories
{
    /// <summary>
    /// To obtain list of sub categories.
    /// </summary>
    /// <returns>The list of sub categories.</returns>
    Task<IEnumerable<SubCategories>> GetListOfSubCategories();
}