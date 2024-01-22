using AutoMapper;
using DiyorMarket.Domain.DTOs.Supplier;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Entities;
using DiyorMarket.Domain.Exceptions;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;
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
        public PaginatedList<SupplierDTO> GetSupplier(SupplierResourseParamentrs paramentrs)
        {
            var query = _context.Suppliers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(paramentrs.SearchString))
            {
                query = query.Where(x => x.FirstName.Contains(paramentrs.SearchString)
                    || x.LastName.Contains(paramentrs.SearchString));
            }
            if (!string.IsNullOrEmpty(paramentrs.OrderBy))
            {
                query = paramentrs.OrderBy.ToLowerInvariant() switch
                {
                    "firstname" => query.OrderBy(x => x.FirstName),
                    "firstnamedesc" => query.OrderByDescending(x => x.FirstName),
                    "lastname" => query.OrderBy(x => x.LastName),
                    "lastnamedesc" => query.OrderByDescending(x => x.LastName),
                    "phonenumber" => query.OrderBy(x => x.PhoneNumber),
                    "phonenumberdesc" => query.OrderByDescending(x => x.PhoneNumber),
                    _ => query.OrderBy(x => x.Id),
                };
            }
            var suppliers = query.ToPaginatedList(paramentrs.Pagesize, paramentrs.PageNumber);

            var suppliersDTO = _mapper.Map<List<SupplierDTO>>(suppliers);

            return new PaginatedList<SupplierDTO>(suppliersDTO, suppliers.TotalCount, suppliers.CurrentPage, suppliers.PageSize);
        }
        public SupplierDTO? GetSupplierById(int id)
        {
            var supplier = _context.Suppliers.FirstOrDefault(supplier => supplier.Id == id);
            if (supplier is null)
            {
                throw new EntityNotFoundException($"Supplier with id: {id} not found");
            }
            return _mapper.Map<SupplierDTO>(supplier);
        }
        public SupplierDTO CreateSupplier(SupplierForCreateDTO supplierForCreate)
        {
            var supplier = _mapper.Map<Supplier>(supplierForCreate);
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();

            return _mapper.Map<SupplierDTO>(supplier);
        }
        public void UpdateSupplier(SupplierForUpdateDTO supplierForUpdate)
        {
            var supplier = _mapper.Map<Supplier>(supplierForUpdate);
            _context.Suppliers.Update(supplier);
            _context.SaveChanges();
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
    }
}
