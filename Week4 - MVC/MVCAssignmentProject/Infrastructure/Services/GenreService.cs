using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Models.RequestModel;
using ApplicationCore.Models.ResponseModel;

namespace Infrastructure.Services;

public class GenreService: IGenreService
{
    private readonly IGenreRepository _genreRepository;

    public GenreService(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public int AddGenre(GenreRequestModel model)
    {
        Genre genre = new Genre();
        genre.Name = model.Name;
        return _genreRepository.Insert(genre);
    }

    public int Update(GenreRequestModel model, int id)
    {
        var genre = _genreRepository.GetById(id);
        genre.Name = genre.Name;
        genre.Id = genre.Id;
        return _genreRepository.Update(genre);
    }

    public int DeleteGenre(int id)
    {
        return _genreRepository.Delete(id);
    }

    public IEnumerable<GenreResponseModel> GetAllGenres()
    {
        var result = _genreRepository.GetAll();
        List<GenreResponseModel> genreResponseModels = new List<GenreResponseModel>();
        foreach (var genre in result)
        {
            var model = new GenreResponseModel();
            model.Name = genre.Name;
            model.Id = genre.Id;
            genreResponseModels.Add(model);
        }

        return genreResponseModels;
    }

    public GenreResponseModel GetGenre(int id)
    {
        var genre = _genreRepository.GetById(id);
        if (genre != null)
        {
            return new GenreResponseModel()
            {
                Id = genre.Id,
                Name = genre.Name
            };
        }

        return null;
    }
}