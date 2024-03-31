using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Management.Domain.Entities;

namespace Store.Management.Infrastructure.Data.Context
{
    /// <summary>
    /// DatabaseContext.
    /// </summary>
    public class DatabaseContext : IdentityDbContext
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// DatabaseContext.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="configuration"></param>
        public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Product.
        /// </summary>
        public DbSet<Product>? Product { get; set; }

        /// <summary>
        /// Category.
        /// </summary>
        public DbSet<Category>? Category { get; set; }

        /// <summary>
        /// SubCategory.
        /// </summary>
        public DbSet<SubCategory>? SubCategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = _configuration["ConnectionStrings:DatabaseConnection"];
            optionsBuilder.UseSqlServer(connection, ef => ef.MigrationsAssembly("Store.Management.Api"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}