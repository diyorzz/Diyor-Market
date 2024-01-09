using DiyorMarket.Domain.DTOs.Supply;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;

namespace DiyorMarket.Domain.Enterfaces.Services
{
    public interface  ISupplyService
    {
        PaginatedList<SupplyDTOs> GetSupply(SupplyResourseParametrs resourseParametrs);
        SupplyDTOs? GetSupplyById(int id);
        SupplyDTOs CreateSupply(SupplyForCreateDTOs supplyForCreate);
        void UpdateSupply(SupplyForUpdateDTOs supplyForUpdate);
        void DeleteSupply(int id);
    }
}
