using Store.Management.Domain.Entities;
using Store.Management.Domain.Interfaces;
using Store.Management.Infrastructure.Data.Context;

namespace Store.Management.Infrastructure.Data.Repositories
{
    /// <summary>
    /// RepositoryCategory.
    /// </summary>
    public class RepositoryCategory : IRepositoryCategory
    {
        private readonly DatabaseContext _context;

        /// <summary>
        /// RepositoryCategory.
        /// </summary>
        /// <param name="context"></param>
        public RepositoryCategory(DatabaseContext context)
        {
            _context = context;
        }

        public List<Category> ObtainAllListOfCategory() => _context?.Category?.ToList();
    }
}