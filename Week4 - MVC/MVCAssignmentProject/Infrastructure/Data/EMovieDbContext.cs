using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class EMovieDbContext: DbContext
{
    public DbSet<Movie> Movies { get; set; } 
    public EMovieDbContext(DbContextOptions<EMovieDbContext> options): base(options)
    {
        
    }
}