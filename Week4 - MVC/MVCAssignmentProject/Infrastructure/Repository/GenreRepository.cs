using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class GenreRepository: BaseRepository<Genre>, IGenreRepository
{
    public GenreRepository(EMovieDbContext eMovieDbContext) : base(eMovieDbContext)
    {
    }
}