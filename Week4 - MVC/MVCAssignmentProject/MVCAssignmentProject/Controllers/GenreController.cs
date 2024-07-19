using ApplicationCore.Contracts.Services;
using ApplicationCore.Models.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace MVCAssignmentProject.Controllers;

public class GenreController : Controller
{
    private readonly IGenreService _service;

    public GenreController(IGenreService service)
    {
        _service = service;
    }
    // GET
    public IActionResult Index()
    {
        var genres = _service.GetAllGenres();
        return View(genres);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(GenreRequestModel model)
    {
        if (ModelState.IsValid)
        {
            _service.AddGenre(model);
            return RedirectToAction("Index");
        }

        return View(model);
    }
}
