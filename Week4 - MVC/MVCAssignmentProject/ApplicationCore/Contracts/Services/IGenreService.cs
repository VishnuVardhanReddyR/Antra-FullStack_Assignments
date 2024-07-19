using ApplicationCore.Models.RequestModel;
using ApplicationCore.Models.ResponseModel;

namespace ApplicationCore.Contracts.Services;

public interface IGenreService
{
    int AddGenre(GenreRequestModel model);
    int Update(GenreRequestModel model, int id);
    int DeleteGenre(int id);
    IEnumerable<GenreResponseModel> GetAllGenres();
    GenreResponseModel GetGenre(int id);
}