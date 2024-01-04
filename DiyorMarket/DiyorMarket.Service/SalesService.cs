using AutoMapper;
using DiyorMarket.Domain.DTOs.Sale;
using DiyorMarket.Domain.DTOs.SaleItam;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Entities;
using DiyorMarket.Domain.Exceptions;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;
using DiyorMarket.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore.Query.Internal;

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

        public SaleDTOs CreateSale(SaleForCreateDTOs saleForCreate)
        {
            var sale=_mapper.Map<Sale>(saleForCreate);

            _context.Sales.Add(sale);
            _context.SaveChanges();

            return _mapper.Map<SaleDTOs>(sale);
        }

        public void DeleteSale(int id)
        {
            var sale = _context.Sales.FirstOrDefault(s => s.Id == id);

            if(sale is not null)
            {
                _context.Sales.Remove(sale);
                _context.SaveChanges();
            }
        }

        public SaleDTOs? GetSaleById(int id)
        {
            var sale = _context.Sales.FirstOrDefault(sale => sale.Id == id);

            if(sale is null)
            {
                throw new EntityNotFoundException($"Product with id: {id} not found");
            }

            return _mapper.Map<SaleDTOs>(sale);
        }

        public PaginatedList<SaleDTOs> Getsales(SaleResourseParametrs parametrs)
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
            var saleItems = query.ToPaginatedList(parametrs.Pagesize, parametrs.PageNumber);

            var saleDTO = _mapper.Map<List<SaleDTOs>>(saleItems);

            return new PaginatedList<SaleDTOs>(saleDTO, saleItems.TotalCount, saleItems.CurrentPage, saleItems.PageSize);
        }

        public void UpdateSale(SaleForUpdateDTOs saleForUpdate)
        {
            var sale = _mapper.Map<Sale>(saleForUpdate);
            _context.Sales.Update(sale);
            _context.SaveChanges();
        }
    }
}
