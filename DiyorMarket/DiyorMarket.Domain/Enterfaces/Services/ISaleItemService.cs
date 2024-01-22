using DiyorMarket.Domain.DTOs.SaleItam;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;

namespace DiyorMarket.Domain.Enterfaces.Services
{
    public interface  ISaleItemService
    {
        PaginatedList<SaleItemDTO> GetSaleItems(SaleItemResorseParametrs parametrs);
        SaleItemDTO? GetSaleItemById(int id);
        SaleItemDTO CreateSaleItem(SaleItemForCreateDTO saleItemForCreate);
        void UpdateSaleItem(SaleItemForUpdateDTO saleItemForUpdate);
        void DeleteSaleItem(int id);
    }
}
