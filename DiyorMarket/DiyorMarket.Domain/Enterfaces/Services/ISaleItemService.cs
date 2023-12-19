using DiyorMarket.Domain.DTOs.SaleItam;

namespace DiyorMarket.Domain.Enterfaces.Services
{
    public interface  ISaleItemService
    {
        IEnumerable<SaleItemDTOs> GetSaleItems();
        SaleItemDTOs? GetSaleItemById(int id);
        SaleItemDTOs CreateSaleItem(SaleItemForCreateDTOs saleItemForCreate);
        void UpdateSaleItem(SaleItemForUpdateDTOs saleItemForUpdate);
        void DeleteSaleItem(int id);
    }
}
