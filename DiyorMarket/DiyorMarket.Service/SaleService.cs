using AutoMapper;
using DiyorMarket.Domain.DTOs.Sale;
using DiyorMarket.Domain.Enterfaces.Repositories;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Entities;
using Serilog;

namespace DiyorMarket.Service
{
    public class SaleService : ISaleService
    {
        private readonly IMapper _mapper;
        private readonly ICommonRepository _repository;
        private readonly ILogger _logger;

        public SaleService(IMapper mapper, ICommonRepository repository, ILogger logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public SaleDTOs CreateSale(SaleForCreateDTOs sale)
        {
            try
            {
                var saleEntity = _mapper.Map<Sale>(sale);
                var createdEntity = _repository.Sale.Create(saleEntity);

                _repository.SaveChanges();

                return _mapper.Map<SaleDTOs>(saleEntity);
            }
            catch (Exception ex)
            {
                _logger.Error("Error creating new sale ", ex);
                throw;
            }
        }
        public void DeleteSale(int id)
        {
            try
            {
                _repository.Sale.Delete(id);
                _repository.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.Error($"Error deleting sale with id : {id}", ex);
                throw;
            }
        }
        public SaleDTOs GetSaleById(int id)
        {
            try
            {
                var sale = _repository.Sale.FindById(id);
                var saleDto = _mapper.Map<SaleDTOs>(sale);

                return saleDto;
            }
            catch (Exception ex)
            {
                _logger.Error($"Error fetching sale with id : {id}", ex);
                throw;
            }
        }
        public IEnumerable<SaleDTOs> GetSales()
        {
            try
            {
                var sales = _repository.Sale.FindAll();
                var saleDto = _mapper.Map<IEnumerable<SaleDTOs>>(sales);

                return saleDto;
            }
            catch (Exception ex)
            {
                _logger.Error("Error fetching sale ", ex);
                throw;
            };
        }

        public IEnumerable<SaleDTOs> Getsales()
        {
            throw new NotImplementedException();
        }

        public void UpdateSale(SaleForUpdateDTOs sale)
        {
            try
            {
                var saleEntity = _mapper.Map<Sale>(sale);
                _repository.Sale.Update(saleEntity);

                _repository.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.Error($"Error updating sale with id : {sale.Id}", ex);
                throw;
            }
        }
    }
}
