using DiyorMarket.Domain.DTOs.Supplier;

namespace DiyorMarket.Domain.Enterfaces.Services
{
    public interface  ISupplier
    {
        IEnumerable<SupplierDTOs> GetSupplier();
        SupplierDTOs? GetSupplierById(int id);
        SupplierDTOs CreateSupplier(SupplierForCreateDTOs supplierForCreate);
        void UpdateSupplier(SupplierForUpdateDTOs supplierForUpdate);
        void DeleteSupplier(int id);
    }
}
