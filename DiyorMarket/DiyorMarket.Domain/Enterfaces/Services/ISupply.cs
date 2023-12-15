using DiyorMarket.Domain.DTOs.Category;
using DiyorMarket.Domain.DTOs.Supply;
using System;


namespace DiyorMarket.Domain.Enterfaces.Services
{
    public interface  ISupply
    {
        IEnumerable<SupplyDTOs> GetSupply();
        SupplyDTOs? GetSupplyById(int id);
        SupplyDTOs CreateSupply(SupplyForCreateDTOs supplyForCreate);
        void UpdateSupply(SupplyForUpdateDTOs supplyForUpdate);
        void DeleteSupply(int id);
    }
}
