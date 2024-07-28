using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.ApplicationCore.Contracts.Services;
using ProductAPI.ApplicationCore.Model.Request;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductControllerAsync : ControllerBase
    {
        private readonly IProductServiceAsync _productServiceAsync;

        public ProductControllerAsync(IProductServiceAsync productServiceAsync)
        {
            _productServiceAsync = productServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _productServiceAsync.GetAllProductsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> PostAync(ProductRequestModel model)
        {
            return Ok(await _productServiceAsync.InsertProductAsync(model));
        }
    }
}
