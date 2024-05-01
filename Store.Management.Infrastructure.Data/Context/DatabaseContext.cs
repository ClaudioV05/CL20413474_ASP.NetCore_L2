using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Management.Domain.Entities;

namespace Store.Management.Infrastructure.Data.Context;

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
    /// Products.
    /// </summary>
    public DbSet<Products>? Products { get; set; }

    /// <summary>
    /// Categories.
    /// </summary>
    public DbSet<Categories>? Categories { get; set; }

    /// <summary>
    /// SubCategories.
    /// </summary>
    public DbSet<SubCategories>? SubCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connection = _configuration["ConnectionStrings:DatabaseConnection"];
        optionsBuilder.UseSqlServer(connection, ef => ef.MigrationsAssembly("Store.Management.Api"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categories>().HasData(new List<Categories>()
        {
            new () { CategoryID = 1, CategoryName = "Mobile" },
            new () { CategoryID = 2, CategoryName = "Laptop" },
            new () { CategoryID = 3, CategoryName = "Smartwatch" }
        });

        modelBuilder.Entity<SubCategories>().HasData(new List<SubCategories>()
        {
            new () { SubCategoryID = 1, CategoryID = 1, SubCategoryName = "Motorola" },
            new () { SubCategoryID = 2, CategoryID = 2, SubCategoryName = "Apple" },
            new () { SubCategoryID = 3, CategoryID = 3, SubCategoryName = "Samsung" }
        });

        modelBuilder.Entity<Products>().HasData(new List<Products>()
        {
            new () { ProductID = 1, SubCategoryID = 1, Quantity = 4, ProductName = "Moto E3 Power (Black, 16 GB)" },
            new () { ProductID = 2, SubCategoryID = 2, Quantity = 6, ProductName = "Macbook Pro" },
            new () { ProductID = 3, SubCategoryID = 3, Quantity = 1, ProductName = "Galaxy Watch 6" }
        });

        base.OnModelCreating(modelBuilder);
    }
}