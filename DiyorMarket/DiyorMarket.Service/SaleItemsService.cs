using AutoMapper;
using DiyorMarket.Domain.DTOs.SaleItam;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Entities;
using DiyorMarket.Domain.Exceptions;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;
using DiyorMarket.Infrastructure.Persistence;

namespace DiyorMarket.Services
{
    public class SaleItemsService : ISaleItemService
    {
        private readonly IMapper _mapper;
        private readonly DiyorMarketDbContext _context;
        public SaleItemsService(IMapper mapper, DiyorMarketDbContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public PaginatedList<SaleItemDTOs> GetSaleItems(SaleItemResorseParametrs parametrs)
        {
            var query = _context.SalesItems.AsQueryable();

            if (parametrs.ProductId is not null)
            {
                query = query.Where(x => x.ProductId == parametrs.ProductId);
            }
            if (parametrs.SaleId is not null)
            {
                query = query.Where(x => x.SaleId == parametrs.SaleId);
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
                    "saleId" => query.OrderBy(x => x.SaleId),
                    "saleIddesc" => query.OrderByDescending(x => x.SaleId),
                    "productId" => query.OrderBy(x => x.ProductId),
                    "productIddesc" => query.OrderByDescending(x => x.ProductId),
                    "unitPrice" => query.OrderBy(x => x.UnitPrice),
                    "unitPricedesc" => query.OrderByDescending(x => x.UnitPrice),
                    _ => query.OrderBy(x => x.Id),
                };
            }
            var saleItems = query.ToPaginatedList(parametrs.Pagesize, parametrs.PageNumber);

            var saleitemsDTO = _mapper.Map<List<SaleItemDTOs>>(saleItems);

            return new PaginatedList<SaleItemDTOs>(saleitemsDTO, saleItems.TotalCount, saleItems.CurrentPage, saleItems.PageSize);
        }
        public SaleItemDTOs? GetSaleItemById(int id)
        {
            var saleItem = _context.SalesItems.FirstOrDefault(sale => sale.Id == id);

            if (saleItem is null)
            {
                throw new EntityNotFoundException($"SaleItem with id: {id} not found");
            }

            return _mapper.Map<SaleItemDTOs?>(saleItem);
        }
        public SaleItemDTOs CreateSaleItem(SaleItemForCreateDTOs saleItemForCreate)
        {
            var saleItem = _mapper.Map<SaleItem>(saleItemForCreate);
            _context.SalesItems.Add(saleItem);
            _context.SaveChanges();

            return _mapper.Map<SaleItemDTOs>(saleItem);
        }
        public void UpdateSaleItem(SaleItemForUpdateDTOs saleItemForUpdate)
        {
            var saleItem = _mapper.Map<SaleItem>(saleItemForUpdate);
            _context.SalesItems.Update(saleItem);
            _context.SaveChanges();
        }
        public void DeleteSaleItem(int id)
        {
            var saleItem = _context.SalesItems.FirstOrDefault(s => s.Id == id);

            if (saleItem is not null)
            {
                _context.SalesItems.Remove(saleItem);
                _context.SaveChanges();
            }
        }
    }
}
