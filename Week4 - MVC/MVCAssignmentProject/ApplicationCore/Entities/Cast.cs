using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

public class Cast
{
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(MAX)")]
    public string Gender { get; set; }
    [Column(TypeName = "nvarchar(128)")]
    public string Name { get; set; }
    [Column(TypeName = "nvarchar(2084)")]
    public string ProfilePath { get; set; }
    [Column(TypeName = "nvarchar(MAX)")]
    public string TmdbUrl { get; set; } 
}