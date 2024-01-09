using AutoMapper;
using DiyorMarket.Domain.DTOs.SupplyItem;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Entities;
using DiyorMarket.Domain.Exceptions;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;
using DiyorMarket.Infrastructure.Persistence;

namespace DiyorMarket.Services
{
    public class SupplyItemsService : ISuppyItemService
    {
        private readonly IMapper _mapper;
        private readonly DiyorMarketDbContext _context;

        public SupplyItemsService(IMapper mapper, DiyorMarketDbContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(context));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public PaginatedList<SupplyItemDTOs> GetSupplyItems(SupplyItemResourceParamentrs parametrs)
        {
            var query = _context.SupplyItems.AsQueryable();

            if (parametrs.ProductId is not null)
            {
                query = query.Where(x => x.ProductId == parametrs.ProductId);
            }
            if (parametrs.SupplyId is not null)
            {
                query = query.Where(x => x.SupplyId == parametrs.SupplyId);
            }
            if (parametrs.QuantityLessThan is not null)
            {
                query = query.Where(x => x.UnitPrice < parametrs.QuantityLessThan);
            }
            if (parametrs.QuantityGreaterThan is not null)
            {
                query = query.Where(x => x.UnitPrice > parametrs.QuantityGreaterThan);
            }
            if (!string.IsNullOrEmpty(parametrs.OrderBy))
            {
                query = parametrs.OrderBy.ToLowerInvariant() switch
                {
                    "supplyId" => query.OrderBy(x => x.SupplyId),
                    "supplyIddesc" => query.OrderByDescending(x => x.SupplyId),
                    "productId" => query.OrderBy(x => x.ProductId),
                    "productIddesc" => query.OrderByDescending(x => x.ProductId),
                    "unitPrice" => query.OrderBy(x => x.UnitPrice),
                    "unitPricedesc" => query.OrderByDescending(x => x.UnitPrice),
                    _ => query.OrderBy(x => x.Id),
                };
            }
            var supplyItems = query.ToPaginatedList(parametrs.Pagesize, parametrs.PageNumber);

            var supplyitemsDTO = _mapper.Map<List<SupplyItemDTOs>>(supplyItems);

            return new PaginatedList<SupplyItemDTOs>(supplyitemsDTO, supplyItems.TotalCount, supplyItems.CurrentPage, supplyItems.PageSize);
        }
        public SupplyItemDTOs? GetSupplyItemById(int id)
        {
            var supplyitem = _context.SupplyItems.FirstOrDefault(s => s.Id == id);
            if (supplyitem is null)
            {
                throw new EntityNotFoundException($"SupplyItem with id: {id} not found");
            }
            return _mapper.Map<SupplyItemDTOs?>(supplyitem);
        }
        public SupplyItemDTOs CreateSuppyItem(SupplyItemForCreateDTOs supplyItemForCreate)
        {
            var supplyItem = _mapper.Map<SupplyItem>(supplyItemForCreate);
            _context.SupplyItems.Add(supplyItem);
            _context.SaveChanges();

            return _mapper.Map<SupplyItemDTOs>(supplyItem);
        }
        public void UpdateSupplyItem(SupplyItemForUpdateDTOs supplyItemForUpdate)
        {
            var supplyItem = _mapper.Map<SupplyItem>(supplyItemForUpdate);
            _context.SupplyItems.Update(supplyItem);
            _context.SaveChanges();
        }
        public void DeleteSupplyItem(int id)
        {
            var supplyitems = _context.SupplyItems.FirstOrDefault(s => s.Id == id);
            if (supplyitems is not null)
            {
                _context.SupplyItems.Remove(supplyitems);
                _context.SaveChanges();
            }
        }
    }
}
