using Microsoft.EntityFrameworkCore;
using Store.Management.Domain.Entities;
using Store.Management.Domain.Interfaces;
using Store.Management.Infrastructure.Data.Context;

namespace Store.Management.Infrastructure.Data.Repositories;

/// <summary>
/// RepositoryCategories.
/// </summary>
public class RepositoryCategories : IRepositoryCategories
{
    private readonly DatabaseContext _context;

    /// <summary>
    /// RepositoryCategories.
    /// </summary>
    /// <param name="context"></param>
    public RepositoryCategories(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Categories>> GetTheListOfCategories() => await _context?.Categories?.AsNoTracking().ToListAsync();
}