using AutoMapper;
using DiyorMarket.Domain.DTOs.SupplyItem;
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
    public class SupplyItemService : ISuppyItem
    {
        private readonly IMapper _mapper;
        private readonly ICommonRepository _repository;
        private readonly ILogger _logger;

        public SupplyItemService(IMapper mapper, ICommonRepository repository, ILogger logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public SupplyItemDTOs CreateSupplyItem(SupplyItemForCreateDTOs createDto)
        {
            try
            {
                var supplyItemEntity = _mapper.Map<SupplyItem>(createDto);
                var createdEntity = _repository.SupplyItem.Create(supplyItemEntity);

                _repository.SaveChanges();

                return _mapper.Map<SupplyItemDTOs>(supplyItemEntity);
            }
            catch (Exception ex)
            {
                _logger.Error("Error creating new supplyItem ", ex);
                throw;
            }
        }

        public SupplyItemDTOs CreateSuppyItem(SupplyItemForCreateDTOs supplyItemForCreate)
        {
            throw new NotImplementedException();
        }

        public void DeleteSupplyItem(int id)
        {
            try
            {
                _repository.SupplyItem.Delete(id);
                _repository.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.Error($"Error deleting supplyItem with id : {id}", ex);
                throw;
            }
        }

        public IEnumerable<SupplyItemDTOs> GetCategories()
        {
            throw new NotImplementedException();
        }

        public SupplyItemDTOs GetSupplyItem(int id)
        {
            try
            {
                var supplyItem = _repository.SupplyItem.FindById(id);
                var supplyItemDto = _mapper.Map<SupplyItemDTOs>(supplyItem);

                return supplyItemDto;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error fetching supplyItem with id : {id}", ex);
                throw;
            }
        }

        public SupplyItemDTOs? GetSupplyItemById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SupplyItemDTOs> GetSupplyItems()
        {
            try
            {
                var supplyItem = _repository.SupplyItem.FindAll();
                var supplyItemDto = _mapper.Map<IEnumerable<SupplyItemDTOs>>(supplyItem);

                return supplyItemDto;
            }
            catch (Exception ex)
            {
                _logger.Error("Error fetching supplyItem ", ex);
                throw;
            }
        }

        public void UpdateSupplyItem(SupplyItemForUpdateDTOs updateDto)
        {
            try
            {
                var supplyItemEntity = _mapper.Map<SupplyItem>(updateDto);
                _repository.SupplyItem.Update(supplyItemEntity);

                _repository.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.Error("Error updating new supplyItem ", ex);
                throw;
            }
        }
    }
}
