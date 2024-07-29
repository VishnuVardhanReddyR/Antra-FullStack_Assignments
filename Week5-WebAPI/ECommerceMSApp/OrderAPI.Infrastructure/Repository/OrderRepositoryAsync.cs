using OrderAPI.ApplicationCore.Contracts.Repository;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.Infrastructure.Data;

namespace OrderAPI.Infrastructure.Repository;

public class OrderRepositoryAsync:BaseRepositoryAsync<Order>, IOrderRepositoryAsync
{
    public OrderRepositoryAsync(OrderDbContext dbContext) : base(dbContext)
    {
    }
}