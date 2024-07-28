using AutoMapper;
using ProductAPI.ApplicationCore.Entities;
using ProductAPI.ApplicationCore.Model.Request;
using ProductAPI.ApplicationCore.Model.Response;

namespace ProductAPI.Helper;

public class ProductMapper:Profile
{
    public ProductMapper()
    {
        CreateMap<Product, ProductResponseModel>().ReverseMap();
        CreateMap<Product, ProductRequestModel>().ReverseMap();
    }   
}