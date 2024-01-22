using AutoMapper;
using DiyorMarket.Domain.DTOs.Sale;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Entities;
using DiyorMarket.Domain.Exceptions;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;
using DiyorMarket.Infrastructure.Persistence;

namespace DiyorMarket.Services
{
    public class SalesService : ISaleService
    {
        private readonly IMapper _mapper;
        private readonly DiyorMarketDbContext _context;
        public SalesService(IMapper mapper, DiyorMarketDbContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public PaginatedList<SaleDTO> Getsales(SaleResourseParametrs parametrs)
        {
            var query = _context.Sales.AsQueryable();

            if (!string.IsNullOrEmpty(parametrs.OrderBy))
            {
                query = parametrs.OrderBy.ToLowerInvariant() switch
                {
                    "customerId" => query.OrderBy(x => x.CustomerId),
                    "customerIddesc" => query.OrderByDescending(x => x.CustomerId),
                    _ => query.OrderBy(x => x.Id),
                };
            }
            var sale = query.ToPaginatedList(parametrs.Pagesize, parametrs.PageNumber);

            var saleDTO = _mapper.Map<List<SaleDTO>>(sale);

            return new PaginatedList<SaleDTO>(saleDTO, sale.TotalCount, sale.CurrentPage, sale.PageSize);
        }
        public SaleDTO? GetSaleById(int id)
        {
            var sale = _context.Sales.FirstOrDefault(sale => sale.Id == id);

            if (sale is null)
            {
                throw new EntityNotFoundException($"Product with id: {id} not found");
            }

            return _mapper.Map<SaleDTO>(sale);
        }
        public SaleDTO CreateSale(SaleForCreateDTO saleForCreate)
        {
            var sale = _mapper.Map<Sale>(saleForCreate);

            _context.Sales.Add(sale);
            _context.SaveChanges();

            return _mapper.Map<SaleDTO>(sale);
        }
        public void UpdateSale(SaleForUpdateDTO saleForUpdate)
        {
            var sale = _mapper.Map<Sale>(saleForUpdate);
            _context.Sales.Update(sale);
            _context.SaveChanges();
        }
        public void DeleteSale(int id)
        {
            var sale = _context.Sales.FirstOrDefault(s => s.Id == id);

            if (sale is not null)
            {
                _context.Sales.Remove(sale);
                _context.SaveChanges();
            }
        }
    }
}
