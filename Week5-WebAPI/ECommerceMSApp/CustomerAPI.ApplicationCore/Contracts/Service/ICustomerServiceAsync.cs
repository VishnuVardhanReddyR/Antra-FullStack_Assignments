using CustomerAPI.ApplicationCore.Model.Request;
using CustomerAPI.ApplicationCore.Model.Response;

namespace CustomerAPI.ApplicationCore.Contracts.Service;

public interface ICustomerServiceAsync
{
    Task<int> InsertCustomerAsync(CustomerRequestModel model);
    Task<IEnumerable<CustomerResponseModel>> GetAllCustomersAsync();
}