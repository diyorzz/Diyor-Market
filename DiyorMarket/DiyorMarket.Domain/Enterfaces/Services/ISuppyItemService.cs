using DiyorMarket.Domain.DTOs.SupplyItem;

namespace DiyorMarket.Domain.Enterfaces.Services
{
    public interface ISuppyItemService
    {
        IEnumerable<SupplyItemDTOs> GetSupplyItems();
        SupplyItemDTOs? GetSupplyItemById(int id);
        SupplyItemDTOs CreateSuppyItem(SupplyItemForCreateDTOs supplyItemForCreate);
        void UpdateSupplyItem(SupplyItemForUpdateDTOs supplyItemForUpdate);
        void DeleteSupplyItem(int id);
    }
}
