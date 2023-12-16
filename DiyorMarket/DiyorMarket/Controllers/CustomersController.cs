using DiyorMarket.Domain.DTOs.Category;
using DiyorMarket.Domain.DTOs.Customer;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Entities;
using DiyorMarket.Service;
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
            _customerService = customerService; throw new ArgumentException(nameof(customerService));
        }



        // GET: api/<CustomersController>
        [HttpGet]
        public ActionResult<IEnumerable<CustomerDtOs>> Get()
        {
            var customers = _customerService.GetCustomers();

            return Ok(customers);
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public ActionResult<CategoryDto> Get(int id)
        {
            var customer = _customerService.GetCustomerById(id);

            return Ok(customer);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public ActionResult<CustomerDtOs> Post([FromBody] CustomerForCereateDTOs customer)
        {
            var createdCustomer = _customerService.CreateCustomer(customer);

            return StatusCode(201);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CustomerForUpdateDTOs customer)
        {
            if (id != customer.Id)
            {
                return BadRequest(
                    $"Route id: {id} does not match with parameter id: {customer.Id}.");
            }

            _customerService.UpdateCustomer(customer);

            return NoContent();
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _customerService.DeleteCustomer(id);

            return NoContent();
        }
    }
}
