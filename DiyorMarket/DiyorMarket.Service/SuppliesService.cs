using AutoMapper;
using DiyorMarket.Domain.DTOs.Supply;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Entities;
using DiyorMarket.Domain.Exceptions;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;
using DiyorMarket.Infrastructure.Persistence;

namespace DiyorMarket.Services
{
    public class SuppliesService : ISupplyService
    {
        private readonly IMapper _mapper;
        private readonly DiyorMarketDbContext _context;
        public SuppliesService(DiyorMarketDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(context));
        }
        public PaginatedList<SupplyDTO> GetSupply(SupplyResourseParametrs parametrs)
        {
            var query = _context.Supplies.AsQueryable();

            if (!string.IsNullOrEmpty(parametrs.OrderBy))
            {
                query = parametrs.OrderBy.ToLowerInvariant() switch
                {
                    "supplierId" => query.OrderBy(x => x.SupplierId),
                    "supplierIddesc" => query.OrderByDescending(x => x.SupplierId),
                    _ => query.OrderBy(x => x.Id),
                };
            }
            var supplies = query.ToPaginatedList(parametrs.Pagesize, parametrs.PageNumber);

            var supplyDTO = _mapper.Map<List<SupplyDTO>>(supplies);

            return new PaginatedList<SupplyDTO>(supplyDTO, supplies.TotalCount, supplies.CurrentPage, supplies.PageSize);
        }
        public SupplyDTO? GetSupplyById(int id)
        {
            var supply = _context.Supplies.FirstOrDefault(supply => supply.Id == id);
            if (supply is null)
            {
                throw new EntityNotFoundException($"Supply with id: {id} not found");
            }
            return _mapper.Map<SupplyDTO?>(supply);
        }
        public SupplyDTO CreateSupply(SupplyForCreateDTO supplyForCreate)
        {
            var supply = _mapper.Map<Supply>(supplyForCreate);
            _context.Supplies.Add(supply);
            _context.SaveChanges();

            return _mapper.Map<SupplyDTO>(supply);
        }
        public void UpdateSupply(SupplyForUpdateDTO supplyForUpdate)
        {
            var supply = _mapper.Map<Supply>(supplyForUpdate);
            _context.Supplies.Update(supply);
            _context.SaveChanges();
        }
        public void DeleteSupply(int id)
        {
            var supply = _context.Supplies.FirstOrDefault(supply => supply.Id == id);
            if (supply is not null)
            {
                _context.Supplies.Remove(supply);
                _context.SaveChanges();
            }
        }
    }
}
