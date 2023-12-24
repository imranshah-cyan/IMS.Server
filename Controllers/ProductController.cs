using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using IMSSPM.Services.ProductService;

namespace IMSSPM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var result = await _productService.GetProducts();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var result = await _productService.GetProduct(id);
            if (result == null)
                return NotFound("Record doesn't exist.");
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            var result = await _productService.AddProduct(product);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Product>> UpdateProduct(Product product)
        {
            var result = await _productService.UpdateProduct(product);
            if (result == null)
                return NotFound("Unable to delete.");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProduct(id);
            if (result == null)
                return NotFound("Unable to delete.");
            return Ok(result);
        }
    }
}
