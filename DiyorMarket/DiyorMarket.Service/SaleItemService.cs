using AutoMapper;
using DiyorMarket.Domain.DTOs.SaleItam;
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
    public class SaleItemService : ISaleItemService
    {
        private readonly IMapper _mapper;
        private readonly ICommonRepository _repository;
        private readonly ILogger _logger;

        public SaleItemService(IMapper mapper, ICommonRepository repository, ILogger logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public SaleItemDTOs GetSaleItems(SaleItemForCreateDTOs saleItem)
        {
            try
            {
                var saleItemEntity = _mapper.Map<SaleItem>(saleItem);
                var createdEntity = _repository.SaleItem.Create(saleItemEntity);

                _repository.SaveChanges();

                return _mapper.Map<SaleItemDTOs>(saleItemEntity);
            }
            catch (Exception ex)
            {
                _logger.Error("Error creating new saleItem ", ex);
                throw;
            }
        }

        public void DeleteSaleItem(int id)
        {
            try
            {
                _repository.SaleItem.Delete(id);
                _repository.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.Error($"Error deleting saleItem with id : {id}", ex);
                throw;
            }
        }

        public SaleItemDTOs GetSaleItem(int id)
        {
            try
            {
                var sale = _repository.SaleItem.FindById(id);
                var saleDto = _mapper.Map<SaleItemDTOs>(sale);

                return saleDto;
            }

            catch (Exception ex)
            {
                _logger.Error($"Error fetching saleItem with id : {id}", ex);
                throw;
            }
        }

        public IEnumerable<SaleItemDTOs> GetSaleItems()
        {
            try
            {
                var sales = _repository.SaleItem.FindAll();
                var saleDto = _mapper.Map<IEnumerable<SaleItemDTOs>>(sales);

                return saleDto;
            }
            catch (Exception ex)
            {
                _logger.Error("Error fetching saleItem ", ex);
                throw;
            };
        }

        public void UpdateSaleItem(SaleItemForUpdateDTOs saleItem)
        {
            try
            {
                var saleEntity = _mapper.Map<SaleItem>(saleItem);
                _repository.SaleItem.Update(saleEntity);

                _repository.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.Error($"Error updating saleItem with id : {saleItem.Id}", ex);
                throw;
            }
        }

        public SaleItemDTOs? GetSaleItemById(int id)
        {
            throw new NotImplementedException();
        }

        public SaleItemDTOs CreateSaleItem(SaleItemForCreateDTOs saleItemForCreate)
        {
            throw new NotImplementedException();
        }
    }
}
