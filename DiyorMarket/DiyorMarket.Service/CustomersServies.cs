using AutoMapper;
using DiyorMarket.Domain.DTOs.Customer;
using DiyorMarket.Domain.Enterfaces.Repositories;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Data.Common;

namespace DiyorMarket.Service
{
    public class CustomersServies : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICommonRepository _repository;
        private readonly ILogger<CustomersServies> _logger;


        public CustomersServies(IMapper mapper, ICommonRepository repository, ILogger<CustomersServies> logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IEnumerable<CustomerDtOs> GetCustomers()
        {
            var customer = _repository.Customer.FindAll();

            var customerDtos = _mapper.Map<IEnumerable<CustomerDtOs>>(customer);

            return customerDtos;
        }

        public CustomerDtOs? GetCustomerById(int id)
        {
            var customer = _repository.Customer.FindById(id);

            var customerDTO = _mapper.Map<CustomerDtOs>(customer);

            return customerDTO;
        }

        public CustomerDtOs CreateCustomer(CustomerForCereateDTOs customerToCreate)
        {
            
                var customerEntity = _mapper.Map<Customer>(customerToCreate);

                _repository.Customer.Create(customerEntity);
                _repository.SaveChanges();

                 return _mapper.Map<CustomerDtOs>(customerEntity);

        }

        public void UpdateCustomer(CustomerForUpdateDTOs customerToUpdate)
        {
            var customerEntity = _mapper.Map<Customer>(customerToUpdate);

            _repository.Customer.Update(customerEntity);
            _repository.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            _repository.Customer.Delete(id);
            _repository.SaveChanges();
        }

    }
}
