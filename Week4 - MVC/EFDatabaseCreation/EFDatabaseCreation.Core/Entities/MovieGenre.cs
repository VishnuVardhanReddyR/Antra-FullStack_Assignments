using System.ComponentModel.DataAnnotations;

namespace EFDatabaseCreation.Core.Entities;

public class MovieGenre
{
    [Required]
    public int GenreId { get; set; }
    public Genre Genre { get; set; }
    [Required]
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
}