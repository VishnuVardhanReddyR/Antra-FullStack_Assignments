using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerAPI.ApplicationCore.Model.Request;

public class CustomerRequestModel
{
    [Required]
    [Column(TypeName="varchar(30)")]
    public string FirstName { get; set; }
    [Required]
    [Column(TypeName="varchar(30)")]
    public string LastName { get; set; }
    [Required]
    [Column(TypeName="varchar(15)")]
    public string Gender { get; set; }
    [Required]
    [Column(TypeName="varchar(11)")]
    public string Phone { get; set; }
}