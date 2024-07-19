using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Models.RequestModel;

public class GenreRequestModel
{
    [Column(TypeName = "nvarchar(24)")]
    public string? Name { get; set; }
}