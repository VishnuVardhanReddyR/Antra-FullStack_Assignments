using CustomerAPI.ApplicationCore.Contracts.Service;
using CustomerAPI.ApplicationCore.Model.Request;
using CustomerAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServiceAsync _customerServiceAsync;

        public CustomerController(ICustomerServiceAsync customerServiceAsync)
        {
            _customerServiceAsync = customerServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _customerServiceAsync.GetAllCustomersAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PostAync(CustomerRequestModel model)
        {
            return Ok(await _customerServiceAsync.InsertCustomerAsync(model));
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://host.docker.internal:50124/");
            HttpResponseMessage message = await client.GetAsync("api/Product");
            if (message != null)
            {
                if (message.IsSuccessStatusCode)
                {
                    var result = await message.Content.ReadFromJsonAsync<List<Product>>();
                    return Ok(result);
                }
            }

            return NoContent();
        }
    }
}
