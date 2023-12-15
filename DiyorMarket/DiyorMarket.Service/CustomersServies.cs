using AutoMapper;
using DiyorMarket.Domain.DTOs.Category;
using DiyorMarket.Domain.DTOs.Customer;
using DiyorMarket.Domain.Enterfaces.Repositories;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Entities;
using Serilog;
using System.Data.Common;

namespace DiyorMarket.Service
{
    public class CustomersServies : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICommonRepository _repository;
        private readonly ILogger _logger;


        public CustomersServies(IMapper mapper, ICommonRepository repository, ILogger logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IEnumerable<CustomerDtOs> GetCustomers()
        {
            try
            {
                var customer = _repository.Customer.FindAll();

                var customerDtos = _mapper.Map<IEnumerable<CustomerDtOs>>(customer);

                return customerDtos;
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.Error($"There was an error mapping between Customer and CustomerDto", ex.Message);
                throw;
            }
            catch (DbException ex)
            {
                _logger.Error("Database error occured while fetching customers.", ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.Error("Something went wrong while fetching customers.", ex.Message);
                throw;
            }
        }

        public CustomerDtOs? GetCustomerById(int id)
        {
            try
            {
                var customer = _repository.Customer.FindById(id);

                var customerDTO = _mapper.Map<CustomerDtOs>(customer);

                return customerDTO;
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.Error($"There was an error mapping between Customer and CustomerDto", ex.Message);
                throw;
            }
            catch (DbException ex)
            {
                _logger.Error($"Database error occured while fetching Customer with id: {id}.", ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong while fetching customer with id: {id}.", ex.Message);
                throw;
            }
        }

        public CustomerDtOs CreateCustomer(CustomerForCereateDTOs customerToCreate)
        {
            try
            {
                var customerEntity = _mapper.Map<Customer>(customerToCreate);

                _repository.Customer.Create(customerEntity);
                _repository.SaveChanges();

                var customerDto = _mapper.Map<CustomerDtOs>(customerEntity);

                return customerDto;
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.Error($"There was an error mapping between customer and CustomerDto", ex.Message);
                throw;
            }
            catch (DbException ex)
            {
                _logger.Error("Database error occured while creating new customer.", ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.Error("Something went wrong while creating new customer.", ex.Message);
                throw;
            }
        }

        public void UpdateCustomer(CustomerForUpdateDTOs customerToUpdate)
        {
            try
            {
                var customerEntity = _mapper.Map<Customer>(customerToUpdate);

                _repository.Customer.Update(customerEntity);
                _repository.SaveChanges();
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.Error($"There was an error mapping between Customer and CustomerDto", ex.Message);
                throw;
            }
            catch (DbException ex)
            {
                _logger.Error("Database error occured while updating customer.", ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.Error("Something went wrong while updating customer.", ex.Message);
                throw;
            }
        }

        public void DeleteCustomer(int id)
        {
            try
            {
                _repository.Customer.Delete(id);
                _repository.SaveChanges();
            }
            catch (DbException ex)
            {
                _logger.Error($"Database error occured while deleting customer with id: {id}.", ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong while deleting customer with id: {id}.", ex.Message);
                throw;
            }
        }

    }
}
