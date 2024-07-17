using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class MovieRepository: BaseRepository<Movie>, IMovieRepository
{
    public MovieRepository(EMovieDbContext eMovieDbContext) : base(eMovieDbContext)
    {
    }
}