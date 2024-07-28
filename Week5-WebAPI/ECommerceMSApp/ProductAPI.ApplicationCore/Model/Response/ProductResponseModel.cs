using System.ComponentModel.DataAnnotations;

namespace ProductAPI.ApplicationCore.Model.Response;

public class ProductResponseModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }
    public string Product_Image { get; set; }
    [Key]
    public int CategoryId { get; set; }
}