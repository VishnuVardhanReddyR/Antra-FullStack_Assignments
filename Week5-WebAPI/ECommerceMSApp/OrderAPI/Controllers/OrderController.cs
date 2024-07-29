using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderAPI.ApplicationCore.Contracts.Services;
using OrderAPI.ApplicationCore.Model.Request;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServiceAsync _orderServiceAsync;

        public OrderController(IOrderServiceAsync orderServiceAsync)
        {
            _orderServiceAsync = orderServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _orderServiceAsync.GetAllOrdersAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(OrderRequestModel model)
        {
            return Ok(await _orderServiceAsync.InsertOrderAsync(model));
        }
    }
}
