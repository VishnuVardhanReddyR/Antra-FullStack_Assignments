using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Entities;

public class Review
{
    [Required]
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
    [Required]
    public int UserId { get; set; }
    public User User { get; set; }
    public DateTime CreatedDate { get; set; }
    [Precision(3, 2)]
    public decimal Rating { get; set; }
    public string ReviewText { get; set; }
}