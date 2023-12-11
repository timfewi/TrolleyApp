using Microsoft.AspNetCore.Mvc;
using Trolley.API.Dtos;
using Trolley.API.Entities;
using Trolley.API.Services;

namespace Trolley.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : BaseController
    {
        private readonly ProductsService _productService;
        public ProductController(IServiceProvider serviceProvider, ProductsService productService) : base(serviceProvider)
        {
            _productService = productService;
        }

        // GET: api/Product
        // Get all products
        [HttpGet]
        public async Task<ActionResult<List<ProductReadDto>>> GetAllProducts()
        {
            try
            {
                var products = await _productService.GetAllProductsAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        // GET: api/Product/{id}
        // Get a product by id
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductReadDto>> GetProductById(int id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(id);
                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }


        //GET: api/Product/Suche
        //Get all products by name
        [HttpGet("Search")]
        public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetProductsByName(string name)
        {
            try
            {
                var products = await _productService.GetProductsByNameAsync(name);
                if (products == null)
                {
                    return NotFound();
                }

                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
