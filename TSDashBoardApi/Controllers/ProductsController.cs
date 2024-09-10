using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using TSDashBoardApi.Application;
using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
        public class ProductsController : ControllerBase
        {
            private readonly IProductService _productService;

            public ProductsController(IProductService productService)
            {
                _productService = productService;
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetProductById(int id)
            {
                var product = await _productService.GetProductByIdAsync(id);
                if (product == null) return NotFound();
                return Ok(product);
            }

            [HttpGet]
            public async Task<IEnumerable<Product>> GetAllProducts()
            {
                return await _productService.GetAllProductsAsync();
            }

            [HttpPost]
            public async Task<IActionResult> AddProduct([FromBody] Product product)
            {
                await _productService.AddProductAsync(product);
                return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
            {
                if (id != product.Id) return BadRequest();

                await _productService.UpdateProductAsync(product);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteProduct(int id)
            {
                await _productService.DeleteProductAsync(id);
                return NoContent();
            }
        }
}
