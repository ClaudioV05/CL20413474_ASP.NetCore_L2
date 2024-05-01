using Microsoft.EntityFrameworkCore;
using Store.Management.Domain.Entities;
using Store.Management.Domain.Interfaces;
using Store.Management.Infrastructure.Data.Context;

namespace Store.Management.Infrastructure.Data.Repositories;

/// <summary>
/// RepositoryProducts.
/// </summary>
public class RepositoryProducts : IRepositoryProducts
{
    private readonly DatabaseContext _context;

    /// <summary>
    /// RepositoryProducts.
    /// </summary>
    /// <param name="context"></param>
    public RepositoryProducts(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Products>> GetTheListOfProducts() => await _context?.Products?.AsNoTracking().ToListAsync();
}