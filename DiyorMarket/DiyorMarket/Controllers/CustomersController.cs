using DiyorMarket.Domain.DTOs.Customer;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
        public ActionResult<IEnumerable<CustomerDTOs>> Get([FromQuery]CustomerResourceParameters parameters)
        {
            var customers = _customerService.GetCustomers(parameters);

            var metaData = GetPaginationMetaData(customers);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));

            return Ok(customers);
        }
        [HttpGet("{id}")]
        public ActionResult<CustomerDTOs> Get(int id)
        {
            var customer = _customerService.GetCustomerById(id);

            return Ok(customer);
        }
        [HttpPost]
        public ActionResult<CustomerDTOs> Post([FromBody] CustomerForCereateDTOs customer)
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
        private PagenationMetaData GetPaginationMetaData(PaginatedList<CustomerDTOs> customerDtOs)
        {
            return new PagenationMetaData
            {
                Totalcount = customerDtOs.TotalCount,
                PageSize = customerDtOs.PageSize,
                CurrentPage = customerDtOs.CurrentPage,
                TotalPages = customerDtOs.TotalPages,
            };
        }
    }
}
