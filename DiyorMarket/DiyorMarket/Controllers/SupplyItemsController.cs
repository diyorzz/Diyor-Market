using DiyorMarket.Domain.DTOs.Supply;
using DiyorMarket.Domain.DTOs.SupplyItem;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
        public ActionResult<IEnumerable<SupplyItemDTOs>> Get([FromQuery]
        SupplyItemResourceParamentrs paramentrs)
        {
            var supplyitems = _suppyItemService.GetSupplyItems(paramentrs);

            var metaData = GetPaginationMetaData(supplyitems);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));

            return Ok(supplyitems);
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
        private PagenationMetaData GetPaginationMetaData(PaginatedList<SupplyItemDTOs> suppliersDTO)
        {
            return new PagenationMetaData
            {
                Totalcount = suppliersDTO.TotalCount,
                PageSize = suppliersDTO.PageSize,
                CurrentPage = suppliersDTO.CurrentPage,
                TotalPages = suppliersDTO.TotalPages,
            };
        }
    }
}
