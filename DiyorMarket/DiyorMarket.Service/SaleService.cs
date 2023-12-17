using AutoMapper;
using DiyorMarket.Domain.DTOs.Sale;
using DiyorMarket.Domain.Enterfaces.Repositories;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Entities;

namespace DiyorMarket.Service
{
    public class SaleService : ISaleService
    {
        private readonly IMapper _mapper;
        private readonly ICommonRepository _repository;

        public SaleService(IMapper mapper, ICommonRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public SaleDTOs CreateSale(SaleForCreateDTOs sale)
        {
            var saleEntity = _mapper.Map<Sale>(sale);

            _repository.Sale.Create(saleEntity);
            _repository.SaveChanges();

            return _mapper.Map<SaleDTOs>(saleEntity);
        }
        public void DeleteSale(int id)
        {
            _repository.Sale.Delete(id);
            _repository.SaveChanges();
        }
        public SaleDTOs GetSaleById(int id)
        {
            var sale = _repository.Sale.FindById(id);
            var saleDto = _mapper.Map<SaleDTOs>(sale);

            return saleDto;
        }

        public IEnumerable<SaleDTOs> Getsales()
        {
            var sales = _repository.Sale.FindAll();
            var saleDto = _mapper.Map<IEnumerable<SaleDTOs>>(sales);

            return saleDto;
        }

        public void UpdateSale(SaleForUpdateDTOs sale)
        {
            var saleEntity = _mapper.Map<Sale>(sale);
            _repository.Sale.Update(saleEntity);

            _repository.SaveChanges();
        }
    }
}
