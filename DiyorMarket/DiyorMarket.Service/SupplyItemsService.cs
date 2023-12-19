using AutoMapper;
using DiyorMarket.Domain.DTOs.Supply;
using DiyorMarket.Domain.DTOs.SupplyItem;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Entities;
using DiyorMarket.Domain.Exceptions;
using DiyorMarket.Infrastructure.Persistence;

namespace DiyorMarket.Services
{
    public class SupplyItemsService : ISuppyItemService
    {
        private readonly IMapper _mapper;
        private readonly DiyorMarketDbContext _context;

        public SupplyItemsService(IMapper mapper, DiyorMarketDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public SupplyItemDTOs CreateSuppyItem(SupplyItemForCreateDTOs supplyItemForCreate)
        {
            var supplyItem = _mapper.Map<SupplyItem>(supplyItemForCreate);
            _context.SupliesItems.Add(supplyItem);
            _context.SaveChanges();

            return _mapper.Map<SupplyItemDTOs>(supplyItem);
        }

        public void DeleteSupplyItem(int id)
        {
            var supplyitems = _context.SupliesItems.FirstOrDefault(s => s.Id == id);
            if (supplyitems is not null)
            {
                _context.SupliesItems.Remove(supplyitems);
                _context.SaveChanges();
            }
        }

        public IEnumerable<SupplyItemDTOs> GetSupplyItems()
        {
            var supplyitem = _context.SupliesItems.ToList();

            return _mapper.Map<IEnumerable<SupplyItemDTOs>>(supplyitem);
        }

        public SupplyItemDTOs? GetSupplyItemById(int id)
        {
            var supplyitem = _context.SupliesItems.FirstOrDefault(s => s.Id == id);
            if (supplyitem is null)
            {
                throw new EntityNotFoundException($"SupplyItem with id: {id} not found");
            }
            return _mapper.Map<SupplyItemDTOs?>(supplyitem);
        }

        public void UpdateSupplyItem(SupplyItemForUpdateDTOs supplyItemForUpdate)
        {
            var supplyItem = _mapper.Map<SupplyItem>(supplyItemForUpdate);
            _context.SupliesItems.Update(supplyItem);
            _context.SaveChanges();
        }
    }
}
