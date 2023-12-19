using DiyorMarket.Domain.DTOs.SupplyItem;

namespace DiyorMarket.Domain.Enterfaces.Services
{
    public interface ISuppyItem
    {
        IEnumerable<SupplyItemDTOs> GetCategories();
        SupplyItemDTOs? GetSupplyItemById(int id);
        SupplyItemDTOs CreateSuppyItem(SupplyItemForCreateDTOs supplyItemForCreate);
        void UpdateSupplyItem(SupplyItemForUpdateDTOs supplyItemForUpdate);
        void DeleteSupplyItem(int id);
    }
}
