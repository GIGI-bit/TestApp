using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApiApp.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiApp.Controllers
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

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            var products = await _productService.GetProducts();
            return Ok(products);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product == null) { return NotFound(); }
            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult<Product>> PostAsync([FromBody] Product product)
        {
            //    var products = await _productService.GetProducts();
            //    product.Id = products.Count() > 0 ? products.Max(p => p.Id) + 1 : 1;
            await _productService.Add(product);
            return Ok(product);

        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Put(int id, [FromBody] Product product)
        {
            product.Id = id;
            var item = await _productService.Update(product);
            return Ok(item);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _productService.Delete(id);
        }
    }
}
