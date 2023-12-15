using AutoMapper;
using DiyorMarket.Domain.DTOs.Supplier;
using DiyorMarket.Domain.Enterfaces.Repositories;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Entities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyorMarket.Service
{
    public class SupplierService : ISupplier
    {
        private readonly IMapper _mapper;
        private readonly ICommonRepository _repository;
        private readonly ILogger _logger;

        public SupplierService(IMapper mapper, ICommonRepository repository, ILogger logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IEnumerable<SupplierDTOs> GetSuppliers()
        {
            try
            {
                var supplier = _repository.Supplier.FindAll();
                var supplierDto = _mapper.Map<IEnumerable<SupplierDTOs>>(supplier);

                return supplierDto;
            }
            catch (Exception ex)
            {
                _logger.Error("Error fetching supplier ", ex);
                throw;
            }
        }

        public SupplierDTOs CreateSupplier(SupplierForCreateDTOs supplier)
        {
            try
            {
                var supplierEntity = _mapper.Map<Supplier>(supplier);
                var createdEntity = _repository.Supplier.Create(supplierEntity);

                _repository.SaveChanges();

                return _mapper.Map<SupplierDTOs>(supplierEntity);
            }
            catch (Exception ex)
            {
                _logger.Error("Error creating new supplier ", ex);
                throw;
            }
        }

        public void DeleteSupplier(int id)
        {
            try
            {
                _repository.Supplier.Delete(id);
                _repository.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.Error($"Error deleting supplier with id : {id}", ex);
                throw;
            }
        }

        public SupplierDTOs GetSupplierById(int id)
        {
            try
            {
                var supplier = _repository.Supplier.FindById(id);
                var supplierDto = _mapper.Map<SupplierDTOs>(supplier);

                return supplierDto;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error fetching supplier with id : {id}", ex);
                throw;
            }
        }

        public void UpdateSupplier(SupplierForUpdateDTOs supplier)
        {
            try
            {
                var supplierEntity = _mapper.Map<Supplier>(supplier);
                _repository.Supplier.Update(supplierEntity);

                _repository.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.Error($"Error updating supplier with id : {supplier.Id}", ex);
                throw;
            }
        }

        public IEnumerable<SupplierDTOs> GetSupplier()
        {
            throw new NotImplementedException();
        }
    }
}
