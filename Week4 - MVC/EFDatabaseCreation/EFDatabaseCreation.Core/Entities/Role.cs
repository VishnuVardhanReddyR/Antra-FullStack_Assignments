using System.ComponentModel.DataAnnotations;

namespace EFDatabaseCreation.Core.Entities;

public class Role
{
    public int Id { get; set; }
    [MaxLength(20)]
    public string Name { get; set; }
}