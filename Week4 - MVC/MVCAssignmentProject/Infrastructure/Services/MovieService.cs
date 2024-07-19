using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Models.RequestModel;
using ApplicationCore.Models.ResponseModel;

namespace Infrastructure.Services;

public class MovieService: IMovieService
{
    private readonly IMovieRepository _movieRepository;

    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }
    public int AddMovie(MovieRequestModel model)
    {
        Movie movie = new Movie();
        movie.Budget = model.Budget;
        movie.Title = model.Title;
        movie.Overview = model.Overview;
        movie.Price = model.Price;
        movie.Revenue = model.Revenue;
        movie.BackdropUrl = model.BackdropUrl;
        movie.ImdbUrl = model.ImdbUrl;
        movie.TmdbUrl = model.TmdbUrl;
        movie.OriginalLanguage = model.OriginalLanguage;
        movie.PosterUrl = model.PosterUrl;
        movie.RunTime = model.RunTime;
        movie.TagLine = model.TagLine;
        movie.CreatedDate = new DateTime();
        movie.UpdatedDate = new DateTime();
        movie.CreatedBy = "current user";
        movie.UpdatedBy = "current user";
        movie.ReleaseDate = new DateTime().AddDays(10);
        
        return _movieRepository.Insert(movie);
    }

    public int UpdateMovie(MovieRequestModel model, int id)
    {
        Movie movie = new Movie();
        movie.Budget = model.Budget;
        movie.Title = model.Title;
        movie.Overview = model.Overview;
        movie.Price = model.Price;
        movie.Revenue = model.Revenue;
        movie.BackdropUrl = model.BackdropUrl;
        movie.ImdbUrl = model.ImdbUrl;
        movie.OriginalLanguage = model.OriginalLanguage;
        movie.PosterUrl = model.PosterUrl;
        movie.RunTime = model.RunTime;
        movie.TagLine = model.TagLine;
        movie.CreatedDate = new DateTime();
        movie.UpdatedDate = new DateTime();
        movie.CreatedBy = "current user";
        movie.UpdatedBy = "current user";
        movie.ReleaseDate = new DateTime().AddDays(10);
        movie.Id = id;
        return _movieRepository.Update(movie);
    }

    public int DeleteMovie(int id)
    {
        return _movieRepository.Delete(id);
    }

    public IEnumerable<MovieResponseModel> GetAllMovies()
    {
        var result = _movieRepository.GetAll();
        List<MovieResponseModel> movieResponseModels = new List<MovieResponseModel>();

        foreach (var movie in result)
        {
            MovieResponseModel model = new MovieResponseModel();
            model.Id = movie.Id;
            model.Budget = movie.Budget;
            model.Title = movie.Title;
            model.Overview = movie.Overview;
            model.Price = movie.Price;
            model.Revenue = movie.Revenue;
            model.BackdropUrl = movie.BackdropUrl;
            model.ImdbUrl = movie.ImdbUrl;
            model.OriginalLanguage = movie.OriginalLanguage;
            model.PosterUrl = movie.PosterUrl;
            model.RunTime = movie.RunTime!;
            model.TagLine = movie.TagLine;
            model.CreatedDate = movie.CreatedDate;
            model.UpdatedDate = movie.UpdatedDate;
            model.CreatedBy = movie.CreatedBy;
            model.UpdatedBy = movie.UpdatedBy;
            model.ReleaseDate = movie.ReleaseDate;
            movieResponseModels.Add(model);
        }

        return movieResponseModels;
    }

    public MovieResponseModel GetMovie(int id)
    {
        var movie = _movieRepository.GetById(id);
        if (movie != null)
            return new MovieResponseModel()
            {
                Id = movie.Id,
                Budget = movie.Budget,
                Title = movie.Title,
                Overview = movie.Overview,
                Price = movie.Price,
                Revenue = movie.Revenue,
                BackdropUrl = movie.BackdropUrl,
                ImdbUrl = movie.ImdbUrl,
                OriginalLanguage = movie.OriginalLanguage,
                PosterUrl = movie.PosterUrl,
                RunTime = movie.RunTime,
                TagLine = movie.TagLine,
                CreatedDate = movie.CreatedDate,
                UpdatedDate = movie.UpdatedDate,
                CreatedBy = movie.CreatedBy,
                UpdatedBy = movie.UpdatedBy,
                ReleaseDate = movie.ReleaseDate
            };
        return null;
    }

    public IEnumerable<MovieResponseModel> GetHighestGrossingMovies()
    {
        var result = _movieRepository.GetHighestGrossingMovies();
        List<MovieResponseModel> movieResponseModels = new List<MovieResponseModel>();

        foreach (var movie in result)
        {
            MovieResponseModel model = new MovieResponseModel();
            model.Id = movie.Id;
            model.Budget = movie.Budget;
            model.Title = movie.Title;
            model.Overview = movie.Overview;
            model.Price = movie.Price;
            model.Revenue = movie.Revenue;
            model.BackdropUrl = movie.BackdropUrl;
            model.ImdbUrl = movie.ImdbUrl;
            model.OriginalLanguage = movie.OriginalLanguage;
            model.PosterUrl = movie.PosterUrl;
            model.RunTime = movie.RunTime!;
            model.TagLine = movie.TagLine;
            model.CreatedDate = movie.CreatedDate;
            model.UpdatedDate = movie.UpdatedDate;
            model.CreatedBy = movie.CreatedBy;
            model.UpdatedBy = movie.UpdatedBy;
            model.ReleaseDate = movie.ReleaseDate;
            movieResponseModels.Add(model);
        }

        return movieResponseModels;
    }
}