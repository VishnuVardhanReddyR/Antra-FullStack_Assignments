using Microsoft.EntityFrameworkCore;
using ProductAPI.ApplicationCore.Entities;

namespace ProductAPI.Infrastructure.Data;

public class ProductDbContext: DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options):base(options)
    {
        
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
}