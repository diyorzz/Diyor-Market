using AutoMapper;
using DiyorMarket.Domain.DTOs.Sale;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Entities;
using DiyorMarket.Domain.Exceptions;
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

        public IEnumerable<SaleDTOs> Getsales()
        {
            var sales=_context.Sales.ToList();

            return _mapper.Map<IEnumerable<SaleDTOs>>(sales);
        }

        public void UpdateSale(SaleForUpdateDTOs saleForUpdate)
        {
            var sale = _mapper.Map<Sale>(saleForUpdate);
            _context.Sales.Update(sale);
            _context.SaveChanges();
        }
    }
}
