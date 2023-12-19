using DiyorMarket.Domain.DTOs.Supply;

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
