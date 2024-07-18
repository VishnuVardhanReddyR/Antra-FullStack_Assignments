using Microsoft.AspNetCore.Mvc;

namespace MVCAssignmentProject.Controllers;

public class UserController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}