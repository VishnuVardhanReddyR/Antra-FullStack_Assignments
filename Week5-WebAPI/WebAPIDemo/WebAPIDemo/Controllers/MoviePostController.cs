using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Model;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviePostController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            string url = "https://jsonplaceholder.typicode.com/posts";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = await client.GetAsync(client.BaseAddress);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadFromJsonAsync<List<Post>>();
                return Ok(result);
            }
            else
            {
                return BadRequest(response.StatusCode);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save(Post p)
        {
            string url = "https://jsonplaceholder.typicode.com/posts";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = await client.PostAsJsonAsync(client.BaseAddress, p);
            if (response.IsSuccessStatusCode)
            {
                return Ok(response.Content.ReadFromJsonAsync<Post>());
            }

            return BadRequest(response.StatusCode);
        }
    }
}
