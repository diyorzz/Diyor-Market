using DiyorMarket.Domain.DTOs.SupplyItem;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;

namespace DiyorMarket.Domain.Enterfaces.Services
{
    public interface ISuppyItemService
    {
        PaginatedList<SupplyItemDTOs> GetSupplyItems(SupplyItemResourceParamentrs supplyItemResource);
        SupplyItemDTOs? GetSupplyItemById(int id);
        SupplyItemDTOs CreateSuppyItem(SupplyItemForCreateDTOs supplyItemForCreate);
        void UpdateSupplyItem(SupplyItemForUpdateDTOs supplyItemForUpdate);
        void DeleteSupplyItem(int id);
    }
}
