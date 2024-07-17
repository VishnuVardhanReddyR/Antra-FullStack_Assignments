using EFDatabaseCreation.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFDatabaseCreation.Infrastructure;

public abstract class MVCDemoDbContext: DbContext
{
    public DbSet<Cast> Casts { get; set; }
    public DbSet<Favorite> Favorites { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<MovieCast> MovieCasts { get; set; }
    public DbSet<MovieGenre> MovieGenres { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Trailer> Trailers { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var conn = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build()
            .GetConnectionString("MVCDemoDb");
        optionsBuilder.UseSqlServer(conn);
    }

    protected override void onModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Favorite>(ConfiguringFavourite);
    }

    private void ConfiguringFavourite(EntityTypeBuilder<Favorite> builder)
    {
        
    }
}