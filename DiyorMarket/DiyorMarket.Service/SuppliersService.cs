using AutoMapper;
using DiyorMarket.Domain.DTOs.Supplier;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Entities;
using DiyorMarket.Domain.Exceptions;
using DiyorMarket.Infrastructure.Persistence;

namespace DiyorMarket.Services
{
    public class SuppliersService : ISupplierService
    {
        private readonly IMapper _mapper;
        private readonly DiyorMarketDbContext _context;
        public SuppliersService(IMapper mapper, DiyorMarketDbContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public SupplierDTOs CreateSupplier(SupplierForCreateDTOs supplierForCreate)
        {
            var supplier = _mapper.Map<Supplier>(supplierForCreate);
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();

            return _mapper.Map<SupplierDTOs>(supplier);
        }

        public void DeleteSupplier(int id)
        {
            var supplier = _context.Suppliers.FirstOrDefault(supplier => supplier.Id == id);
            if (supplier is not null)
            {
                _context.Suppliers.Remove(supplier);
                _context.SaveChanges();
            }
        }

        public IEnumerable<SupplierDTOs> GetSupplier()
        {
            var suppliers=_context.Suppliers.ToList();

            return _mapper.Map<IEnumerable<SupplierDTOs>>(suppliers);
        }

        public SupplierDTOs? GetSupplierById(int id)
        {
            var supplier= _context.Suppliers.FirstOrDefault(supplier => supplier.Id == id);
            if(supplier is null)
            {
                throw new EntityNotFoundException($"Supplier with id: {id} not found");
            }
            return _mapper.Map<SupplierDTOs>(supplier);
        }

        public void UpdateSupplier(SupplierForUpdateDTOs supplierForUpdate)
        {
            var supplier = _mapper.Map<Supplier>(supplierForUpdate);
            _context.Suppliers.Update(supplier);
            _context.SaveChanges();
        }
    }
}
