using ApplicationCore.Models.RequestModel;
using ApplicationCore.Models.ResponseModel;

namespace ApplicationCore.Contracts.Services;

public interface IMovieService
{
    int AddMovie(MovieRequestModel model);
    int UpdateMovie(MovieRequestModel model, int id);
    int DeleteMovie(int id);
    IEnumerable<MovieResponseModel> GetAllMovies();
    MovieResponseModel GetMovie(int id);
    IEnumerable<MovieResponseModel> GetHighestGrossingMovies();

    IEnumerable<MovieResponseModel> GetMoviesByGenre(int id);
}