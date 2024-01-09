using DiyorMarket.Domain.DTOs.Sale;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiyorMarket.Controllers
{
    [Route("api/sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SaleDTOs>> Get([FromQuery] SaleResourseParametrs parametrs)
        {
            var sales = _saleService.Getsales(parametrs);

            var metaData = GetPaginationMetaData(sales);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));

            return Ok(sales);
        }

        [HttpGet("{id}")]
        public ActionResult<SaleDTOs> Get(int id)
        {
            var sales=_saleService.GetSaleById(id);

            return Ok(sales);
        }

        [HttpPost]
        public ActionResult<SaleDTOs> Post([FromBody] SaleForCreateDTOs saleFor)
        {
            _saleService.CreateSale(saleFor);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] SaleForUpdateDTOs sale)
        {
            _saleService.UpdateSale(sale);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _saleService.DeleteSale(id);

            return NoContent();
        }
        private PagenationMetaData GetPaginationMetaData(PaginatedList<SaleDTOs> saleDtOs)
        {
            return new PagenationMetaData
            {
                Totalcount = saleDtOs.TotalCount,
                PageSize = saleDtOs.PageSize,
                CurrentPage = saleDtOs.CurrentPage,
                TotalPages = saleDtOs.TotalPages,
            };
        }
    }
}
