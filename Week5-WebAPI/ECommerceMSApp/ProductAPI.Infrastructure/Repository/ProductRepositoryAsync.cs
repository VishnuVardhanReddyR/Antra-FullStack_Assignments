using ProductAPI.ApplicationCore.Contracts.Repository;
using ProductAPI.ApplicationCore.Entities;
using ProductAPI.Infrastructure.Data;

namespace ProductAPI.Infrastructure.Repository;

public class ProductRepositoryAsync: BaseRepositoryAsync<Product>, IProductRespositoryAsync
{
    public ProductRepositoryAsync(ProductDbContext dbContext) : base(dbContext)
    {
    }
}