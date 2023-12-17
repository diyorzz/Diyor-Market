using AutoMapper;
using DiyorMarket.Domain.DTOs.Customer;
using DiyorMarket.Domain.Enterfaces.Repositories;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace DiyorMarket.Service
{
    public class CustomersServies : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICommonRepository _repository;

        public CustomersServies(IMapper mapper, ICommonRepository repository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
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

            var cretedCustomer = _mapper.Map<CustomerDtOs>(customerEntity);
            return cretedCustomer;

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
