using Microsoft.EntityFrameworkCore;
using Store.Management.Domain.Entities;
using Store.Management.Domain.Interfaces;
using Store.Management.Infrastructure.Data.Context;

namespace Store.Management.Infrastructure.Data.Repositories
{
    /// <summary>
    /// RepositoryProduct.
    /// </summary>
    public class RepositoryProduct : IRepositoryProduct
    {
        private readonly DatabaseContext _context;

        /// <summary>
        /// RepositoryProduct.
        /// </summary>
        /// <param name="context"></param>
        public RepositoryProduct(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Products>> GetTheListOfProduct() => await _context?.Products?.AsNoTracking().ToListAsync();
    }
}