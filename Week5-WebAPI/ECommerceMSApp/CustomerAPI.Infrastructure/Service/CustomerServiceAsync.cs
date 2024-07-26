using AutoMapper;
using CustomerAPI.ApplicationCore.Contracts.Respository;
using CustomerAPI.ApplicationCore.Contracts.Service;
using CustomerAPI.ApplicationCore.Entities;
using CustomerAPI.ApplicationCore.Model.Request;
using CustomerAPI.ApplicationCore.Model.Response;

namespace CustomerAPI.Infrastructure.Service;

public class CustomerServiceAsync: ICustomerServiceAsync
{
    private readonly ICustomerRepositoryAsync _customerRepositoryAsync;
    private readonly IMapper _mapper;

    public CustomerServiceAsync(ICustomerRepositoryAsync customerRepositoryAsync, IMapper mapper)
    {
        _customerRepositoryAsync = customerRepositoryAsync;
        _mapper = mapper;
    }
    public async Task<int> InsertCustomerAsync(CustomerRequestModel model)
    {
        Customer c = _mapper.Map<Customer>(model);
        return await _customerRepositoryAsync.InsertAsync(c);
    }

    public async Task<IEnumerable<CustomerResponseModel>> GetAllCustomersAsync()
    {
        return _mapper.Map<IEnumerable<CustomerResponseModel>>(await _customerRepositoryAsync.GetAllAsync());
    }
}