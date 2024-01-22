using DiyorMarket.Domain.DTOs.Supply;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;

namespace DiyorMarket.Domain.Enterfaces.Services
{
    public interface  ISupplyService
    {
        PaginatedList<SupplyDTO> GetSupply(SupplyResourseParametrs resourseParametrs);
        SupplyDTO? GetSupplyById(int id);
        SupplyDTO CreateSupply(SupplyForCreateDTO supplyForCreate);
        void UpdateSupply(SupplyForUpdateDTO supplyForUpdate);
        void DeleteSupply(int id);
    }
}
