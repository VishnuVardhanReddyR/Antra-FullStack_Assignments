using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Entities;

public class Purchase
{
    [Required]
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
    [Required]
    public int UserId { get; set; }
    public User User { get; set; }
    public DateTime PurchaseDateTime { get; set; }
    public Guid PurchaseNumber { get; set; }
    [Precision(5, 2)]
    public decimal TotalPrice { get; set; }
}