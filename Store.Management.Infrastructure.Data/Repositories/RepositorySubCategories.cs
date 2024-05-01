using Microsoft.EntityFrameworkCore;
using Store.Management.Domain.Entities;
using Store.Management.Domain.Interfaces;
using Store.Management.Infrastructure.Data.Context;

namespace Store.Management.Infrastructure.Data.Repositories;

/// <summary>
/// RepositorySubCategories.
/// </summary>
public class RepositorySubCategories : IRepositorySubCategories
{
    private readonly DatabaseContext _context;

    /// <summary>
    /// RepositorySubCategories.
    /// </summary>
    /// <param name="context"></param>
    public RepositorySubCategories(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SubCategories>> GetListOfSubCategories() => await _context?.SubCategories?.AsNoTracking().ToListAsync();
}