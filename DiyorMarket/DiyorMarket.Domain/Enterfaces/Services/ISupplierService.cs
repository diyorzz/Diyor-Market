using DiyorMarket.Domain.DTOs.Supplier;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;

namespace DiyorMarket.Domain.Enterfaces.Services
{
    public interface  ISupplierService
    {
        PaginatedList<SupplierDTO> GetSupplier(SupplierResourseParamentrs paramentrs);
        SupplierDTO? GetSupplierById(int id);
        SupplierDTO CreateSupplier(SupplierForCreateDTO supplierForCreate);
        void UpdateSupplier(SupplierForUpdateDTO supplierForUpdate);
        void DeleteSupplier(int id);
    }
}
