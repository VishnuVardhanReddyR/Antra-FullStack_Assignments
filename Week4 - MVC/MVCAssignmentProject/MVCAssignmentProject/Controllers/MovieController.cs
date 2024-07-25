using System.Diagnostics;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models.RequestModel;
using ApplicationCore.Models.ResponseModel;
using Infrastructure.Repository;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MVCAssignmentProject.Controllers;

public class MovieController : Controller
{
    private readonly IMovieService _service;
    private readonly IGenreService _genreService;
    private int GenreId; 

    public MovieController(IMovieService service, IGenreService genreService)
    {
        _service = service;
        _genreService = genreService;
    }
    // GET
    public IActionResult Index()
    {
        var movies = _service.GetAllMovies();
        var result = _genreService.GetAllGenres().Select(x => new { Key = x.Id, Value = x.Name });
        ViewBag.GenresList = new SelectList(result, "Key", "Value");
        return View(movies);
    }
    [HttpGet]
    public IActionResult Create(){
    
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
        var model = _service.GetMovie(movieId);
        return View(model);
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

    [HttpGet]
    public IActionResult GrosserFilter()
    {
        var movies = _service.GetHighestGrossingMovies();
        // ViewBag["movies"] = movies;
        return View("index", movies);
    }

    [HttpGet]
    public IActionResult Genre()
    {
        return RedirectToAction("Index", "Genre", "Index");
    }

    [HttpPost]
    public IActionResult MoviesByGenre(int GenreId)
    {
        var movies = _service.GetMoviesByGenre(GenreId);
        return View("index", movies);
    }

    [HttpGet]
    public IActionResult MovieDetail(int movieId)
    {
        var movie = _service.GetMovie(movieId);
        return View();
    }
    
}