using DiyorMarket.Domain.DTOs.Product;
using DiyorMarket.Domain.DTOs.SaleItam;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiyorMarket.Controllers
{
    [Route("api/saleitems")]
    [ApiController]
    public class SaleItemsController : ControllerBase
    {
        private readonly ISaleItemService _saleItemService;

        public SaleItemsController(ISaleItemService saleItemService)
        {
            _saleItemService = saleItemService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SaleItemDTOs>> Get([FromQuery]
        SaleItemResorseParametrs parametrs)
        {
            var saleitems=_saleItemService.GetSaleItems(parametrs);

            var metaData = GetPaginationMetaData(saleitems);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));

            return Ok(saleitems);
        }
        [HttpGet("{id}")]
        public ActionResult<SaleItemDTOs> Get(int id)
        {
           var saleitem=_saleItemService.GetSaleItemById(id);
            return Ok(saleitem);
        }

        [HttpPost]
        public ActionResult<ProductDto> Post([FromBody] SaleItemForCreateDTOs saleItem)
        {
            _saleItemService.CreateSaleItem(saleItem);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] SaleItemForUpdateDTOs saleItem)
        {
            _saleItemService.UpdateSaleItem(saleItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _saleItemService.DeleteSaleItem(id);
            return NoContent();
        }
        private PagenationMetaData GetPaginationMetaData(PaginatedList<SaleItemDTOs> saleItemDtOs)
        {
            return new PagenationMetaData
            {
                Totalcount = saleItemDtOs.TotalCount,
                PageSize = saleItemDtOs.PageSize,
                CurrentPage = saleItemDtOs.CurrentPage,
                TotalPages = saleItemDtOs.TotalPages,
            };
        }
    }
    class PagenationMetaData
    {
        public int Totalcount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
