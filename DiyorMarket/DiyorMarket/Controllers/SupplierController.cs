using DiyorMarket.Domain.DTOs.Customer;
using DiyorMarket.Domain.DTOs.Sale;
using DiyorMarket.Domain.DTOs.Supplier;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiyorMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SupplierDTO>> Get([FromQuery]SupplierResourseParamentrs paramentrs)
        {
            var supplier=_supplierService.GetSupplier(paramentrs);

            var metaData = GetPaginationMetaData(supplier);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));

            return Ok(supplier);
        }
        [HttpGet("{id}")]
        public ActionResult<SupplierDTO> Get(int id)
        {
            var supplier= _supplierService.GetSupplierById(id);
            return Ok(supplier);
        }

        [HttpPost]
        public ActionResult<SaleDTO> Post([FromBody] SupplierForCreateDTO supplier)
        {
            _supplierService.CreateSupplier(supplier);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] SupplierForUpdateDTO supplier)
        {
            _supplierService.UpdateSupplier(supplier);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _supplierService.DeleteSupplier(id);
            return NoContent();
        }
        private PagenationMetaData GetPaginationMetaData(PaginatedList<SupplierDTO> suppliersDTO)
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
