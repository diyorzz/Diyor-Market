using DiyorMarket.Domain.DTOs.Supplier;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;

namespace DiyorMarket.Domain.Enterfaces.Services
{
    public interface  ISupplierService
    {
        PaginatedList<SupplierDTOs> GetSupplier(SupplierResourseParamentrs paramentrs);
        SupplierDTOs? GetSupplierById(int id);
        SupplierDTOs CreateSupplier(SupplierForCreateDTOs supplierForCreate);
        void UpdateSupplier(SupplierForUpdateDTOs supplierForUpdate);
        void DeleteSupplier(int id);
    }
}
