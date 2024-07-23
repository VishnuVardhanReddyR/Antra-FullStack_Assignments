using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.Repositories;

public interface IMovieRepository: IRepository<Movie>
{
    IEnumerable<Movie> GetHighestGrossingMovies();
    IEnumerable<Movie> GetMoviesByGenre(int id);
}