using Microsoft.AspNetCore.Mvc;

namespace MVCAssignmentProject.Controllers;

public class AdminController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}