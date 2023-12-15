using AutoMapper;
using DiyorMarket.Domain.DTOs.Supply;
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
    public class SupplyService : ISupply
    {
        private readonly IMapper _mapper;
        private readonly ICommonRepository _repository;
        private readonly ILogger _logger;

        public SupplyService(IMapper mapper, ICommonRepository repository, ILogger logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public SupplyDTOs CreateSupply(SupplyForCreateDTOs supply)
        {
            try
            {
                var supplyEntity = _mapper.Map<Supply>(supply);
                var createdEntity = _repository.Supply.Create(supplyEntity);

                _repository.SaveChanges();

                return _mapper.Map<SupplyDTOs>(supplyEntity);
            }
            catch (Exception ex)
            {
                _logger.Error("Error creating new supply ", ex);
                throw;
            }
        }

        public void DeleteSupply(int id)
        {
            try
            {
                _repository.Supply.Delete(id);
                _repository.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.Error($"Error deleting supply with id : {id}", ex);
                throw;
            }
        }

        public IEnumerable<SupplyDTOs> GetSupplies()
        {
            try
            {
                var supply = _repository.Supply.FindAll();
                var supplyDto = _mapper.Map<IEnumerable<SupplyDTOs>>(supply);

                return supplyDto;
            }
            catch (Exception ex)
            {
                _logger.Error("Error fetching supply ", ex);
                throw;
            }
        }

        public IEnumerable<SupplyDTOs> GetSupply()
        {
            throw new NotImplementedException();
        }

        public SupplyDTOs GetSupplyById(int id)
        {
            try
            {
                var supply = _repository.Supply.FindById(id);
                var supplyDto = _mapper.Map<SupplyDTOs>(supply);

                return supplyDto;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error fetching supply with id : {id}", ex);
                throw;
            }
        }

        public void UpdateSupply(SupplyForUpdateDTOs supply)
        {
            try
            {
                var supplyEntity = _mapper.Map<Supply>(supply);
                _repository.Supply.Update(supplyEntity);

                _repository.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.Error("Error updating new supply ", ex);
                throw;
            }
        }
    }
}
