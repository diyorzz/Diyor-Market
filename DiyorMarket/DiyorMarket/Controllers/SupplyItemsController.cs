using DiyorMarket.Domain.DTOs.Supply;
using DiyorMarket.Domain.DTOs.SupplyItem;
using DiyorMarket.Domain.Enterfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiyorMarket.Controllers
{
    [Route("api/supplyitems")]
    [ApiController]
    public class SupplyItemsController : ControllerBase
    {
        private readonly ISuppyItemService _suppyItemService;
        
        public SupplyItemsController(ISuppyItemService suppyItemService)
        {
            _suppyItemService = suppyItemService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SupplyItemDTOs>> Get()
        {
            var supplyItems = _suppyItemService.GetSupplyItems();

            return Ok(supplyItems);
        }

        [HttpGet("{id}")]
        public ActionResult<SupplyDTOs> Get(int id)
        {
            var supplyitem = _suppyItemService.GetSupplyItemById(id);

            return Ok(supplyitem);
        }

        [HttpPost]
        public ActionResult<SupplyItemDTOs> Post([FromBody] SupplyItemForCreateDTOs supply)
        {
            _suppyItemService.CreateSuppyItem(supply);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] SupplyItemForUpdateDTOs supply)
        {
            _suppyItemService.UpdateSupplyItem(supply);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _suppyItemService.DeleteSupplyItem(id);
            return NoContent();
        }
    }
}
