using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Entities;

[PrimaryKey(nameof(CastId), nameof(MovieId))]
public class MovieCast
{
    [Key, Column(Order = 0)]
    public int CastId { get; set; }
    public Cast Cast { get; set; }
    [Column(TypeName = "nvarchar(450)")]
    public string Character { get; set; }
    [Key, Column(Order = 1)]
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
}