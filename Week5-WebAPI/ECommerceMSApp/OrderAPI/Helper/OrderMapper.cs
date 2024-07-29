using AutoMapper;
using OrderAPI.ApplicationCore.Entities;
using OrderAPI.ApplicationCore.Model.Request;
using OrderAPI.ApplicationCore.Model.Response;

namespace OrderAPI.Helper;

public class OrderMapper:Profile
{
    public OrderMapper()
    {
        CreateMap<Order, OrderRequestModel>().ReverseMap();
        CreateMap<Order, OrderResponseModel>().ReverseMap();
    }
}
