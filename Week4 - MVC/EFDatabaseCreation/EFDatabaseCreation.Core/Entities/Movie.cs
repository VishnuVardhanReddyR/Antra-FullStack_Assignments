using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EFDatabaseCreation.Core.Entities;

public class Movie
{
    public int id { get; set; }
    [MaxLength(2084)]
    public string? BackdropUrl { get; set; }
    [Precision(18, 4)]
    public decimal? Budget { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    [MaxLength(2084)]
    public string? ImdbUrl { get; set; }
    [MaxLength(64)]
    public string? OriginalLanguage { get; set; }
    public string? Overview { get; set; }
    [MaxLength(2084)]
    public string? PosterUrl { get; set; }
    [Precision(5, 2)]
    public decimal? Price { get; set; }
    public DateTime? ReleaseDate { get; set; }
    [Precision(18, 4)]
    public decimal? Revenue { get; set; }
    public int? RunTime { get; set; }
    [MaxLength(512)]
    public string? TagLine { get; set; }
    [MaxLength(256)]
    public string? Title { get; set; }
    [MaxLength(2084)]
    public string? TmdbUrl { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
}