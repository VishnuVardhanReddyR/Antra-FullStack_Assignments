using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerAPI.ApplicationCore.Entities;

public class CustomerAddress
{
    public int Id { get; set; }
    [Required]
    [Column(TypeName="varchar(50)")]
    public string Street { get; set; }
    [Required]
    [Column(TypeName="varchar(20)")]
    public string City { get; set; }
    [Required]
    [Column(TypeName="varchar(10)")]
    public string State { get; set; }
    [Required]
    [Column(TypeName="varchar(30)")]
    public string Country { get; set; }
    [Required]
    [Column(TypeName="varchar(10)")]
    public string PostalCode { get; set; }
    public bool IsDefaultAddress { get; set; } = false;
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } 
}