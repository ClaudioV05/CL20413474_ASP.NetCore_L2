using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Store.Management.Models
{
    public class DatabaseContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = _configuration.GetValue<string>("ConnectionStrings:DatabaseConnection");

            if (string.IsNullOrEmpty(connection))
            {
                connection = "Data Source=sai-pc; UID=sa; Password=Pass$123; Database=StoreManagement;";
            }

            optionsBuilder.UseSqlServer(connection);
        }
    }
}