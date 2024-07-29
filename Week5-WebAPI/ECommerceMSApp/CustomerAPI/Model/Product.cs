namespace CustomerAPI.Model;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public int Quantity { get; set; }
    public string Product_Image { get; set; }
    public int CategoryId { get; set; }
}