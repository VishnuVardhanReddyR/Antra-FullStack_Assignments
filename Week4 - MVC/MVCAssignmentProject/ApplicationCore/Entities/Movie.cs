using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

public class Movie
{
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(2084)")]
    public string? BackdropUrl { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal? Budget { get; set; }
    [Column(TypeName = "nvarchar(MAX)")]
    public string? CreatedBy { get; set; }
    [Column(TypeName = "datetime2")]
    public DateTime? CreatedDate { get; set; }
    [Column(TypeName = "nvarchar(2084)")]
    public string? ImdbUrl { get; set; }
    [Column(TypeName = "nvarchar(64)")]
    public string? OriginalLanguage { get; set; }
    [Column(TypeName = "nvarchar(2084)")]
    public string? Overview { get; set; }
    [Column(TypeName = "nvarchar(2084)")]
    public string PosterUrl { get; set; }
    [Column(TypeName = "decimal(6,2)")]
    public decimal? Price { get; set; }
    [Column(TypeName = "datetime2")]
    public DateTime? ReleaseDate { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal? Revenue { get; set; }
    [Column(TypeName = "int")]
    public int? RunTime { get; set; }
    [Column(TypeName = "nvarchar(512)")]
    public string? TagLine { get; set; }
    [Column(TypeName = "nvarchar(256)")]
    public string? Title { get; set; }
    [Column(TypeName = "nvarchar(2084)")]
    public string? TmdbUrl { get; set; }
    [Column(TypeName = "nvarchar(MAX)")]
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
}