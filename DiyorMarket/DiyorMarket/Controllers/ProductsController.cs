using DiyorMarket.Domain.DTOs.Product;
using DiyorMarket.Domain.Enterfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiyorMarket.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> Get()
        {
            var products=_productService.GetProducts();

            return Ok(products);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult<ProductDto> Get(int id)
        {
            var product =_productService.GetProductById(id);    
            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult<ProductDto> Post([FromBody] ProductForCreateDTOs product)
        {
            _productService.CreateProduct(product);

            return StatusCode(201);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ProductForUpdateDTOs product)
        {
            _productService.UpdateProduct(product);
            return NoContent();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);
            return NoContent(); 
        }
    }
}
