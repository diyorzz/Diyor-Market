﻿using DiyorMarket.Domain.DTOs.Product;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
        public ActionResult<IEnumerable<ProductDTO>> Get([FromQuery]
        ProductResourceParameters productResourceParameters)
        {
            var products = _productService.GetProducts(productResourceParameters);

            var metaData = GetPaginationMetaData(products);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));

            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDTO> Get(int id)
        {
            var product = _productService.GetProductById(id);
            return Ok(product);
        }
        [HttpPost]
        public ActionResult<ProductDTO> Post([FromBody] ProductForCreateDTO product)
        {
            _productService.CreateProduct(product);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] ProductForUpdateDTO product)
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
        private PagenationMetaData GetPaginationMetaData(PaginatedList<ProductDTO> products)
        {
            return new PagenationMetaData
            {
                Totalcount = products.TotalCount,
                PageSize = products.PageSize,
                CurrentPage = products.CurrentPage,
                TotalPages = products.TotalPages,
            };
        }
    }
}
