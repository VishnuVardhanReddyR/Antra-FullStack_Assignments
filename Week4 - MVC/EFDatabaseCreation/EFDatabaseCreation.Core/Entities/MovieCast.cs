using System.ComponentModel.DataAnnotations;

namespace EFDatabaseCreation.Core.Entities;

public class MovieCast
{
    [Required]
    public int CastId { get; set; }
    public Cast Cast { get; set; }
    [MaxLength(450)]
    public string Character { get; set; }
    [Required]
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
}