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
        public DbSet<Products>? Products { get; set; }

        /// <summary>
        /// Category.
        /// </summary>
        public DbSet<Categories>? Categories { get; set; }

        /// <summary>
        /// SubCategory.
        /// </summary>
        public DbSet<SubCategories>? SubCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = _configuration["ConnectionStrings:DatabaseConnection"];
            optionsBuilder.UseSqlServer(connection, ef => ef.MigrationsAssembly("Store.Management.Api"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>().HasData(new List<Categories>(){new Categories()
            { 
                CategoryID = 1,
                CategoryName = "Mobile"
            }});

            modelBuilder.Entity<SubCategories>().HasData(new List<SubCategories>(){new SubCategories()
            {
                SubCategoryID = 1,
                CategoryID = 1,
                SubCategoryName = "Motorola"
            }});

            modelBuilder.Entity<Products>().HasData(new List<Products>(){new Products()
            { 
                ProductID = 1,
                SubCategoryID = 1,
                ProductName = "Moto E3 Power (Black, 16 GB)"
            }});

            base.OnModelCreating(modelBuilder);
        }
    }
}