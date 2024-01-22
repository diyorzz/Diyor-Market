using DiyorMarket.Domain.DTOs.Sale;
using DiyorMarket.Domain.DTOs.Supply;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiyorMarket.Controllers
{
    [Route("api/supplies")]
    [ApiController]
    public class SuppliesController : ControllerBase
    {
        private readonly ISupplyService _supplyService;
        public SuppliesController(ISupplyService supplyService)
        {
            _supplyService = supplyService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SupplyDTO>> Get([FromQuery] SupplyResourseParametrs paramentrs)
        {
            var supply = _supplyService.GetSupply(paramentrs);

            var metaData = GetPaginationMetaData(supply);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));

            return Ok(supply);
        }

        [HttpGet("{id}")]
        public ActionResult<SupplyDTO> Get(int id)
        {
            var supply = _supplyService.GetSupplyById(id);

            return Ok(supply);
        }

        [HttpPost]
        public ActionResult<SaleDTO> Post([FromBody] SupplyForCreateDTO supply)
        {
            _supplyService.CreateSupply(supply);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] SupplyForUpdateDTO supply)
        {
            _supplyService.UpdateSupply(supply);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _supplyService?.DeleteSupply(id);
            return NoContent();
        }
        private PagenationMetaData GetPaginationMetaData(PaginatedList<SupplyDTO> suppliersDTO)
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
