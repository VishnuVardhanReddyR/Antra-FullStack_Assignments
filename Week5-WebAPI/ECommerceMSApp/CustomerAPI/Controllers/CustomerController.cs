using CustomerAPI.ApplicationCore.Contracts.Service;
using CustomerAPI.ApplicationCore.Model.Request;
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
    }
}
