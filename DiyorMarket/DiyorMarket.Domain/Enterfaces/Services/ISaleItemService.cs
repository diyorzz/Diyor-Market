using DiyorMarket.Domain.DTOs.SaleItam;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;

namespace DiyorMarket.Domain.Enterfaces.Services
{
    public interface  ISaleItemService
    {
        PaginatedList<SaleItemDTos> GetSaleItems(SaleItemResorseParametrs parametrs);
        SaleItemDTos? GetSaleItemById(int id);
        SaleItemDTos CreateSaleItem(SaleItemForCreateDTOs saleItemForCreate);
        void UpdateSaleItem(SaleItemForUpdateDTOs saleItemForUpdate);
        void DeleteSaleItem(int id);
    }
}
