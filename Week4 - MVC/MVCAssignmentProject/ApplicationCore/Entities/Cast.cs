using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities;

public class Cast
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Gender { get; set; }
    [MaxLength(128)]
    public string Name { get; set; }
    [MaxLength(2084)]
    public string ProfilePath { get; set; }
    public string TmdbUrl { get; set; } 
}