using Microsoft.AspNetCore.Mvc;

namespace MVCAssignmentProject.Controllers;

public class AccountController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}