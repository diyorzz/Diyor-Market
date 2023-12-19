using AutoMapper;
using DiyorMarket.Domain.DTOs.Supply;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Entities;
using DiyorMarket.Domain.Exceptions;
using DiyorMarket.Infrastructure.Persistence;

namespace DiyorMarket.Services
{
    public class SuppliesService : ISupplyService
    {
        private readonly IMapper _mapper;
        private readonly DiyorMarketDbContext _context;
        public SuppliesService(DiyorMarketDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public SupplyDTOs CreateSupply(SupplyForCreateDTOs supplyForCreate)
        {
            var supply = _mapper.Map<Supply>(supplyForCreate);
            _context.Supllies.Add(supply);
            _context.SaveChanges();

            return _mapper.Map<SupplyDTOs>(supply);
        }

        public void DeleteSupply(int id)
        {
            var supply=_context.Supllies.FirstOrDefault(supply => supply.Id == id);
            if(supply is not null)
            {
                _context.Supllies.Remove(supply);
                _context.SaveChanges();
            }
        }

        public IEnumerable<SupplyDTOs> GetSupply()
        {
            var supplies = _context.Supllies.ToList();

            return _mapper.Map<IEnumerable<SupplyDTOs>>(supplies);
        }

        public SupplyDTOs? GetSupplyById(int id)
        {
            var supply = _context.Supllies.FirstOrDefault(supply => supply.Id == id);
            if(supply is null)
            {
                throw new EntityNotFoundException($"Supply with id: {id} not found");
            }
            return _mapper.Map<SupplyDTOs?>(supply);
        }

        public void UpdateSupply(SupplyForUpdateDTOs supplyForUpdate)
        {
            var supply = _mapper.Map<Supply>(supplyForUpdate);
            _context.Supllies.Update(supply);
            _context.SaveChanges();
        }
    }
}
