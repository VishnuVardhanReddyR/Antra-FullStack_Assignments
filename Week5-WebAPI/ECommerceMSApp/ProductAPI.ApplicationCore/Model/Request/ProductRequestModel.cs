using System.ComponentModel.DataAnnotations;
using ProductAPI.ApplicationCore.Entities;

namespace ProductAPI.ApplicationCore.Model.Request;

public class ProductRequestModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }
    public string Product_Image { get; set; }
    [Key]
    public int CategoryId { get; set; }
}