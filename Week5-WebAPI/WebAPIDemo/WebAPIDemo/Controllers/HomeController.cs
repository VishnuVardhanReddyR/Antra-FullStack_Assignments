using Microsoft.AspNetCore.Mvc;

namespace WebAPIDemo.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        List<string> values = new List<string> { "One", "Two", "Three", "Four" };
        return Ok(values);
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetById(int id)
    {
        return Redirect("https://www.google.com");
    } 
    
    [HttpGet]
    [Route("{city}")]
    public IActionResult GetByCity(string city)
    {
        return Ok("The city name we are quering = " + city);
    }
    
    [HttpGet("{dept}")]
    public IActionResult GetByDepartment(string dept)
    {
        return Ok("The department name we are querying = " + dept);
    }
    
    [HttpPost]
    public IActionResult Post()
    {
        return Ok();
    }
    
    [HttpPut]
    public IActionResult Put()
    {
        return Ok();
    }
}