using ApplicationCore.Contracts.Services;
using ApplicationCore.Models.RequestModel;
using ApplicationCore.Models.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace MVCAssignmentProject.Controllers;

public class MovieController : Controller
{
    private readonly IMovieService _service;

    public MovieController(IMovieService service)
    {
        _service = service;
    }
    // GET
    public IActionResult Index()
    {
        var movies = _service.GetAllMovies();
        return View(movies);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(MovieRequestModel model)
    {
        if (ModelState.IsValid)
        {
            _service.AddMovie(model);
            return RedirectToAction("Index");
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult Edit(int movieId)
    {
        var result = _service.GetMovie(movieId);
        return View(result);
    }

    [HttpPost]
    public IActionResult Edit(MovieResponseModel model)
    {
        if (ModelState.IsValid)
        {
            MovieRequestModel movie = new MovieRequestModel();
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
            _service.UpdateMovie(movie, model.Id);
            return RedirectToAction("Index");
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult Delete(int movieId)
    {
        var result = _service.GetMovie(movieId);
        return View(result);
    }

    [HttpPost]
    public IActionResult Delete(MovieResponseModel model)
    {
        _service.DeleteMovie(model.Id);
        return RedirectToAction("Index");
    }
}