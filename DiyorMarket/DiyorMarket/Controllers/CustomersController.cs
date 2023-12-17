using DiyorMarket.Domain.DTOs.Customer;
using DiyorMarket.Domain.Enterfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiyorMarket.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CustomerDtOs>> Get()
        {
            var customers = _customerService.GetCustomers();

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerDtOs> Get(int id)
        {
            var customer = _customerService.GetCustomerById(id);

            return Ok(customer);
        }

        [HttpPost]
        public ActionResult<CustomerDtOs> Post([FromBody] CustomerForCereateDTOs customer)
        {
             _customerService.CreateCustomer(customer);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromRoute]int id, [FromBody] CustomerForUpdateDTOs customer)
        {
            if (id != customer.Id)
            {
                return BadRequest(
                    $"Route id: {id} does not match with parameter id: {customer.Id}.");
            }

            _customerService.UpdateCustomer(customer);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _customerService.DeleteCustomer(id);

            return NoContent();
        }
    }
}
