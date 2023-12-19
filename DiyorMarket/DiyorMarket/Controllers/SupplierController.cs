using DiyorMarket.Domain.DTOs.Sale;
using DiyorMarket.Domain.DTOs.Supplier;
using DiyorMarket.Domain.Enterfaces.Services;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<IEnumerable<SaleDTOs>> Get()
        {
            var supplier=_supplierService.GetSupplier();

            return Ok(supplier);
        }

        [HttpGet("{id}")]
        public ActionResult<SupplierDTOs> Get(int id)
        {
            var supplier= _supplierService.GetSupplierById(id);
            return Ok(supplier);
        }

        [HttpPost]
        public ActionResult<SaleDTOs> Post([FromBody] SupplierForCreateDTOs supplier)
        {
            _supplierService.CreateSupplier(supplier);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] SupplierForUpdateDTOs supplier)
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
    }
}
