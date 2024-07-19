using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class MovieGenreRepository: BaseRepository<MovieGenre>, IMovieGenreRepository
{
    public MovieGenreRepository(EMovieDbContext eMovieDbContext) : base(eMovieDbContext)
    { 
    }
}