using DiyorMarket.Domain.DTOs.Product;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
        public ActionResult<IEnumerable<ProductDto>> Get([FromQuery]
        ProductResourceParameters productResourceParameters)
        {
            var products = _productService.GetProducts(productResourceParameters);

            var metaData = GetPaginationMetaData(products);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));

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
        private PagenationMetaData GetPaginationMetaData(PaginatedList<ProductDto> products)
        {
            return new PagenationMetaData
            {
                Totalcount = products.TotalCount,
                PageSize = products.PageSize,
                CurrentPage = products.CurrentPage,
                TotalPages = products.TotalPages,
            };
        }
        class PagenationMetaData
        {
            public int Totalcount { get; set; }
            public int PageSize { get; set; }
            public int CurrentPage { get; set; }
            public int TotalPages { get; set; }
        }
    }
}
