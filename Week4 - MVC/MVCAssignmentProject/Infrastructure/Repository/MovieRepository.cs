using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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

    public IEnumerable<Movie> GetMoviesByGenre(int id)
    {
        var query = from movie in _eMovieDbContext.Movies
            join movieGenres in _eMovieDbContext.MovieGenres on movie.Id equals movieGenres.MovieId
            join genres in _eMovieDbContext.Genres on movieGenres.GenreId equals genres.Id
            where genres.Id == id
            select movie;
        return query.ToList();
    }

}