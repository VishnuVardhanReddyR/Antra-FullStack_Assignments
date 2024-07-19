using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Models.ResponseModel;

public class GenreResponseModel
{
    public int Id { get; set; }
    [Column(TypeName = "nvarchar(24)")]
    public string? Name { get; set; }
}