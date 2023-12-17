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

        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> Get()
        {
            var products=_productService.GetProducts();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto> Get(int id)
        {
            var product =_productService.GetProductById(id);    
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<ProductDto> Post([FromBody] ProductForCreateDTOs product)
        {
            _productService.CreateProduct(product);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ProductForUpdateDTOs product)
        {
            _productService.UpdateProduct(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);
            return NoContent(); 
        }
    }
}
