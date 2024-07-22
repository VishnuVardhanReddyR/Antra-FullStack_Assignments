using ApplicationCore.Models.RequestModel;
using ApplicationCore.Models.ResponseModel;

namespace ApplicationCore.Contracts.Services;

public interface IMovieGenreService
{
    int AddMovieGenre(MovieGenreRequestModel model);
    int UpdateMovieGenre(MovieGenreRequestModel model, int id);
    int DeleteMovieGenre(int id);
    IEnumerable<MovieGenreResponseModel> GetAllMovieGenres();
    MovieGenreResponseModel GetMovieGenres(int id);
}