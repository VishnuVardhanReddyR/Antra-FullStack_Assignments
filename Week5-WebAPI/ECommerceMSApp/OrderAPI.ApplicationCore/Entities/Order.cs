using System.ComponentModel.DataAnnotations;

namespace OrderAPI.ApplicationCore.Entities;

public class Order
{
    public int Id { get; set; }
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