using System.ComponentModel.DataAnnotations;

namespace EFDatabaseCreation.Core.Entities;

public class Trailer
{
    public int Id { get; set; }
    [Required]
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
    public string Name { get; set; }
    public string TrailerUrl { get; set; }
}