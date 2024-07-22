using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Entities;

namespace ApplicationCore.Models.ResponseModel;

public class MovieGenreResponseModel
{
    [Key, Column(Order = 0)]
    public int GenreId { get; set; }
    public Genre Genre { get; set; }
    [Key, Column(Order = 1)]
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
}