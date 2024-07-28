using ProductAPI.ApplicationCore.Model.Request;
using ProductAPI.ApplicationCore.Model.Response;

namespace ProductAPI.ApplicationCore.Contracts.Services;

public interface IProductServiceAsync
{
    Task<int> InsertProductAsync(ProductRequestModel model);
    Task<IEnumerable<ProductResponseModel>> GetAllProductsAsync();
}