using AutoMapper;
using DiyorMarket.Domain.DTOs.SaleItam;
using DiyorMarket.Domain.Enterfaces.Repositories;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Entities;

namespace DiyorMarket.Service
{
    public class SaleItemService : ISaleItemService
    {
        private readonly IMapper _mapper;
        private readonly ICommonRepository _repository;

        public SaleItemService(IMapper mapper, ICommonRepository repository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public SaleItemDTOs GetSaleItems(SaleItemForCreateDTOs saleItem)
        {
            var saleItemEntity = _mapper.Map<SaleItem>(saleItem);
            var createdEntity = _repository.SaleItem.Create(saleItemEntity);

            _repository.SaveChanges();

            return _mapper.Map<SaleItemDTOs>(saleItemEntity);
        }

        public void DeleteSaleItem(int id)
        {
            _repository.SaleItem.Delete(id);
            _repository.SaveChanges();
        }

        public SaleItemDTOs GetSaleItem(int id)
        {
            var sale = _repository.SaleItem.FindById(id);
            var saleDto = _mapper.Map<SaleItemDTOs>(sale);

            return saleDto;
        }

        public IEnumerable<SaleItemDTOs> GetSaleItems()
        {
            var sales = _repository.SaleItem.FindAll();
            var saleDto = _mapper.Map<IEnumerable<SaleItemDTOs>>(sales);

            return saleDto;
        }

        public void UpdateSaleItem(SaleItemForUpdateDTOs saleItem)
        {
            var saleEntity = _mapper.Map<SaleItem>(saleItem);
            _repository.SaleItem.Update(saleEntity);

            _repository.SaveChanges();
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
