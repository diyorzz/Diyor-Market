using AutoMapper;
using DiyorMarket.Domain.DTOs.Customer;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Entities;
using DiyorMarket.Domain.Exceptions;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;
using DiyorMarket.Infrastructure.Persistence;

namespace DiyorMarket.Services
{
    public class CustomersService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly DiyorMarketDbContext _context;
        public CustomersService(IMapper mapper, DiyorMarketDbContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public PaginatedList<CustomerDTOs> GetCustomers(CustomerResourceParameters parameters)
        {
            var query = _context.Customers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(parameters.SearchString))
            {
                query = query.Where(x => x.FirstName.Contains(parameters.SearchString)
                    || x.LastName.Contains(parameters.SearchString));
            }
            if (!string.IsNullOrEmpty(parameters.OrderBy))
            {
                query = parameters.OrderBy.ToLowerInvariant() switch
                {
                    "firstname" => query.OrderBy(x => x.FirstName),
                    "firstnamedesc" => query.OrderByDescending(x => x.FirstName),
                    "lastname" => query.OrderBy(x => x.LastName),
                    "lastnamedesc" => query.OrderByDescending(x => x.LastName),
                    _ => query.OrderBy(x => x.Id),
                };
            }
            var customer = query.ToPaginatedList(parameters.Pagesize, parameters.PageNumber);

            var customerDTO = _mapper.Map<List<CustomerDTOs>>(customer);
            var customerDTO = _mapper.Map<List<CustomerDTOs>>(customer);

            return new PaginatedList<CustomerDTOs>(customerDTO, customer.TotalCount, customer.CurrentPage, customer.PageSize);
        }
        public CustomerDTOs? GetCustomerById(int id)
        {
            var customers = _context.Customers.FirstOrDefault(c => c.Id == id);

            if (customers == null)
            {
                throw new EntityNotFoundException($"Customer with id: {id} not found");
            }

            return _mapper.Map<CustomerDTOs>(customers);
        }
        public CustomerDTOs CreateCustomer(CustomerForCereateDTOs customerForCereate)
        {
            var customer = _mapper.Map<Customer>(customerForCereate);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return _mapper.Map<CustomerDTOs>(customer);
        }
        public void UpdateCustomer(CustomerForUpdateDTOs customerForUpdate)
        {
            var customer = _mapper.Map<Customer>(customerForUpdate);

            _context.Customers.Update(customer);
            _context.SaveChanges();
        }
        public void DeleteCustomer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);

            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }
    }
}
