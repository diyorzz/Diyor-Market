using DiyorMarket.Domain.DTOs.Category;
using DiyorMarket.Domain.DTOs.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
