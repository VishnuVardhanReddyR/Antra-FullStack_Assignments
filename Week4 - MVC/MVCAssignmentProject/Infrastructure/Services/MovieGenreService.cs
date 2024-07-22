using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models.RequestModel;
using ApplicationCore.Models.ResponseModel;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infrastructure.Services;

public class MovieGenreService: IMovieGenreService
{
    private readonly MovieGenreRepository _movieGenreRepository;

    public MovieGenreService(MovieGenreRepository movieGenreRepository )
    {
        _movieGenreRepository = movieGenreRepository;
    }
    public int AddMovieGenre(MovieGenreRequestModel model)
    {
        MovieGenre genre = new MovieGenre();
        genre.MovieId = model.MovieId;
        genre.GenreId = model.GenreId;
        return _movieGenreRepository.Insert(genre);
    }

    public int UpdateMovieGenre(MovieGenreRequestModel model, int id)
    {
        MovieGenre movieGenre = new MovieGenre();
        movieGenre.GenreId = model.GenreId;
        movieGenre.MovieId = id;
        return _movieGenreRepository.Update(movieGenre);
    }

    public int DeleteMovieGenre(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<MovieGenreResponseModel> GetAllMovieGenres()
    {
        throw new NotImplementedException();
    }

    public MovieGenreResponseModel GetMovieGenres(int id)
    {
        throw new NotImplementedException();
    }
}