using Microsoft.AspNetCore.Mvc;

namespace MVCAssignmentProject.Controllers;

public class CastController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}