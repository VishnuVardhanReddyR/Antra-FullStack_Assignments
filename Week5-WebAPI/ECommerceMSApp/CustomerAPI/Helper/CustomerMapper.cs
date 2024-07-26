using AutoMapper;
using CustomerAPI.ApplicationCore.Entities;
using CustomerAPI.ApplicationCore.Model.Request;
using CustomerAPI.ApplicationCore.Model.Response;

namespace CustomerAPI.Helper;

public class CustomerMapper:Profile
{
    public CustomerMapper()
    {
        CreateMap<Customer, CustomerResponseModel>().ReverseMap();
        CreateMap<Customer, CustomerRequestModel>().ReverseMap();
    }
}