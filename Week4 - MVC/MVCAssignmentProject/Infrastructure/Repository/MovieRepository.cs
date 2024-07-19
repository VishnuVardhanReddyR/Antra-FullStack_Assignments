using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class MovieRepository: BaseRepository<Movie>, IMovieRepository
{
    private readonly EMovieDbContext _eMovieDbContext;

    public MovieRepository(EMovieDbContext eMovieDbContext) : base(eMovieDbContext)
    {
        _eMovieDbContext = eMovieDbContext;
    }

    public IEnumerable<Movie> GetHighestGrossingMovies()
    {
        return _eMovieDbContext.Movies
            .OrderByDescending(m => m.Revenue)
            .ToList();
    }
}