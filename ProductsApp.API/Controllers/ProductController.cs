using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductsApp.API.DTOs.Request;
using ProductsApp.API.DTOs.Response;
using ProductsApp.API.Services;
using ProductsApp.Data.Models;

namespace ProductsApp.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public async Task<ProductDtoResponse> GetById(int id)
        {
            return await _productService.GetByIdAsync(id);
        }

        [HttpGet("{id}/with-categories")]
        public async Task<ProductDtoResponse> GetByIdWithCategories(int id)
        {
            return await _productService.GetByIdWithCategoriesAsync(id);
        }

        [HttpGet("with-categories")]
        public async Task<ActionResult<IEnumerable<ProductDtoResponse>>> GetAllWithCategories()
        {
            var products = await _productService.GetAllWithCategoriesAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDtoResponse>> AddProduct([FromBody] ProductDtoRequest dto)
        {
            var product = await _productService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetByIdWithCategories), new {id=product.ProductId},product);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            await _productService.RemoveProductAsync(productId);
            return NoContent();
        }

    }
}
