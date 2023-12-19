using DiyorMarket.Domain.DTOs.Product;
using DiyorMarket.Domain.DTOs.SaleItam;
using DiyorMarket.Domain.Enterfaces.Services;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<IEnumerable<SaleItemDTOs>> Get()
        {
            var saleitems=_saleItemService.GetSaleItems();
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
    }
}
