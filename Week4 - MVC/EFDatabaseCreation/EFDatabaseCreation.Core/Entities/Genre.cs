using System.ComponentModel.DataAnnotations;

namespace EFDatabaseCreation.Core.Entities;

public class Genre
{
    public int Id { get; set; }
    [MaxLength(24)]
    public string? Name { get; set; }
}