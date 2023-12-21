using DiyorMarket.Domain.DTOs.SaleItam;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;

namespace DiyorMarket.Domain.Enterfaces.Services
{
    public interface  ISaleItemService
    {
        PaginatedList<SaleItemDTOs> GetSaleItems(SaleItemResorseParametrs parametrs);
        SaleItemDTOs? GetSaleItemById(int id);
        SaleItemDTOs CreateSaleItem(SaleItemForCreateDTOs saleItemForCreate);
        void UpdateSaleItem(SaleItemForUpdateDTOs saleItemForUpdate);
        void DeleteSaleItem(int id);
    }
}
