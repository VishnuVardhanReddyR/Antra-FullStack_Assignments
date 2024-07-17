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
}