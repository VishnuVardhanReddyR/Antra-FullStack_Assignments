using AutoMapper;
using ProductAPI.ApplicationCore.Contracts.Repository;
using ProductAPI.ApplicationCore.Contracts.Services;
using ProductAPI.ApplicationCore.Entities;
using ProductAPI.ApplicationCore.Model.Request;
using ProductAPI.ApplicationCore.Model.Response;

namespace ProductAPI.Infrastructure.Services;

public class ProductServiceAsync: IProductServiceAsync
{
    private readonly IProductRespositoryAsync _productRespositoryAsync;
    private readonly IMapper _mapper;

    public ProductServiceAsync(IProductRespositoryAsync productRespositoryAsync, IMapper mapper)
    {
        _productRespositoryAsync = productRespositoryAsync;
        _mapper = mapper;
    }
    public async Task<int> InsertProductAsync(ProductRequestModel model)
    {
        Product p = _mapper.Map<Product>(model);
        Console.WriteLine(p);
        return await _productRespositoryAsync.InsertAsync(p);
    }

    public async Task<IEnumerable<ProductResponseModel>> GetAllProductsAsync()
    {
        return _mapper.Map<IEnumerable<ProductResponseModel>>(await _productRespositoryAsync.GetAllAsync());
    }
}