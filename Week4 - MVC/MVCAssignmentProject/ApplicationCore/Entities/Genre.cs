using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

public class Genre
{
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(24)")]
    public string? Name { get; set; }
}