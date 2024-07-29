using System.ComponentModel.DataAnnotations;

namespace OrderAPI.ApplicationCore.Model.Request;

public class OrderRequestModel
{
    public string OrderDate { get; set; }
    [Required]
    public int CustomerID { get; set; }
    public string CustomerName { get; set; }
    [Required]
    public int PaymentMethodId { get; set; }
    public string PaymentName { get; set; }
    public string ShippingAddress { get; set; }
    public string ShippingMethod { get; set; }
    public int BillAmount { get; set; }
    public string OrderStatus { get; set; }
}