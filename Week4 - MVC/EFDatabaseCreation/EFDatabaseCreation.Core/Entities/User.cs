using System.ComponentModel.DataAnnotations;

namespace EFDatabaseCreation.Core.Entities;

public class User
{
    public int Id { get; set; }
    public DateTime? DateOfBirth { get; set; }
    [MaxLength(256)]
    public string Email { get; set; }
    [MaxLength(128)]
    public string FirstName { get; set; }
    [MaxLength(1024)]
    public string HashedPassword { get; set; }
    public Boolean IsLocked { get; set; }
    [MaxLength(128)]
    public string LastName { get; set; }
    [MaxLength(16)]
    public string? PhoneNumber { get; set; }
    public string? ProfilePictureUrl { get; set; }
    [MaxLength(1024)]
    public string? Salt { get; set; }
}