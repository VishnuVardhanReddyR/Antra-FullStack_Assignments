using OrderAPI.ApplicationCore.Model.Request;
using OrderAPI.ApplicationCore.Model.Response;

namespace OrderAPI.ApplicationCore.Contracts.Services;

public interface IOrderServiceAsync
{
    Task<int> InsertOrderAsync(OrderRequestModel model);
    Task<IEnumerable<OrderResponseModel>> GetAllOrdersAsync();
}