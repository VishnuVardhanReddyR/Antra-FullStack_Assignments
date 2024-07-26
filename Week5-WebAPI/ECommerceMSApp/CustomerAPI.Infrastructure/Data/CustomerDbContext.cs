using CustomerAPI.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Infrastructure.Data;

public class CustomerDbContext:DbContext
{
    public CustomerDbContext(DbContextOptions<CustomerDbContext> options):base(options)
    {
        
    }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerAddress> CustomerAddresses { get; set; }
}