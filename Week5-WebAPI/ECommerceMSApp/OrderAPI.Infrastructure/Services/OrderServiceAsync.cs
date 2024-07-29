using AutoMapper;
using OrderAPI.ApplicationCore.Contracts.Repository;
using OrderAPI.ApplicationCore.Contracts.Services;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.ApplicationCore.Model.Request;
using OrderAPI.ApplicationCore.Model.Response;

namespace OrderAPI.Infrastructure.Services;

public class OrderServiceAsync:IOrderServiceAsync
{
    private readonly IOrderRepositoryAsync _orderRepositoryAsync;
    private readonly IMapper _mapper;

    public OrderServiceAsync(IOrderRepositoryAsync orderRepositoryAsync, IMapper mapper)
    {
        _orderRepositoryAsync = orderRepositoryAsync;
        _mapper = mapper;
    }
    public async Task<int> InsertOrderAsync(OrderRequestModel model)
    {
        Order o = _mapper.Map<Order>(model);
        return await _orderRepositoryAsync.InsertAsync(o);
    }

    public async Task<IEnumerable<OrderResponseModel>> GetAllOrdersAsync()
    {
        return _mapper.Map<IEnumerable<OrderResponseModel>>(await _orderRepositoryAsync.GetAllAsync());
    }
}