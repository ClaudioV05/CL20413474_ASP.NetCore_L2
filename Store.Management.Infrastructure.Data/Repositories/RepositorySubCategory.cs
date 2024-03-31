using Microsoft.EntityFrameworkCore;
using Store.Management.Domain.Entities;
using Store.Management.Domain.Interfaces;
using Store.Management.Infrastructure.Data.Context;

namespace Store.Management.Infrastructure.Data.Repositories
{
    /// <summary>
    /// RepositorySubCategory.
    /// </summary>
    public class RepositorySubCategory : IRepositorySubCategory
    {
        private readonly DatabaseContext _context;

        /// <summary>
        /// RepositoryCategory.
        /// </summary>
        /// <param name="context"></param>
        public RepositorySubCategory(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SubCategory>> GetListOfSubCategory() => await _context?.SubCategories?.AsNoTracking().ToListAsync();
    }
}