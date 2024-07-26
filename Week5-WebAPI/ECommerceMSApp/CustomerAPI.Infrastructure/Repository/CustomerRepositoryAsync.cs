using CustomerAPI.ApplicationCore.Contracts.Respository;
using CustomerAPI.ApplicationCore.Entities;
using CustomerAPI.Infrastructure.Data;

namespace CustomerAPI.Infrastructure.Repository;

public class CustomerRepositoryAsync: BaseRepositoryAsync<Customer>, ICustomerRepositoryAsync
{
    public CustomerRepositoryAsync(CustomerDbContext dbContext) : base(dbContext)
    {
    }
}