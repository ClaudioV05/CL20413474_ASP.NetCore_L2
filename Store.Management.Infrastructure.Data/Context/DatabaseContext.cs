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
        public DbSet<Product>? Products { get; set; }

        /// <summary>
        /// Category.
        /// </summary>
        public DbSet<Category>? Categories { get; set; }

        /// <summary>
        /// SubCategory.
        /// </summary>
        public DbSet<SubCategory>? SubCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = _configuration["ConnectionStrings:DatabaseConnection"];
            optionsBuilder.UseSqlServer(connection, ef => ef.MigrationsAssembly("Store.Management.Api"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new List<Category>(){new Category()
            { 
                CategoryID = 1,
                CategoryName = "Mobile"
            }});

            modelBuilder.Entity<SubCategory>().HasData(new List<SubCategory>(){new SubCategory()
            {
                SubCategoryID = 1,
                CategoryID = 1,
                SubCategoryName = "Motorola"
            }});

            modelBuilder.Entity<Product>().HasData(new List<Product>(){new Product()
            { 
                ProductID = 1,
                SubCategoryID = 1,
                ProductName = "Moto E3 Power (Black, 16 GB)"
            }});

            base.OnModelCreating(modelBuilder);
        }
    }
}