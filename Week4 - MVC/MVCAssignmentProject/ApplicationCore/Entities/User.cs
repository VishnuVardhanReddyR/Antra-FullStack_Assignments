using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

public class User
{
    public int Id { get; set; }
    public DateTime? DateOfBirth { get; set; }
    [Column(TypeName = "nvarchar(256)")]
    public string Email { get; set; }
    [Column(TypeName = "nvarchar(128)")]
    public string FirstName { get; set; }
    [Column(TypeName = "nvarchar(1024)")]
    public string HashedPassword { get; set; }
    [Column(TypeName = "bit")]
    public Boolean IsLocked { get; set; }
    [Column(TypeName = "nvarchar(128)")]
    public string LastName { get; set; }
    [Column(TypeName = "nvarchar(16)")]
    public string? PhoneNumber { get; set; }
    [Column(TypeName = "nvarchar(MAX)")]
    public string? ProfilePictureUrl { get; set; }
    [Column(TypeName = "nvarchar(1024)")]
    public string? Salt { get; set; }
}