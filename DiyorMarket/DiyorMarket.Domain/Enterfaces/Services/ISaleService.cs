using DiyorMarket.Domain.DTOs.Sale;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;

namespace DiyorMarket.Domain.Enterfaces.Services
{
    public interface ISaleService
    {
        PaginatedList<SaleDTO> Getsales(SaleResourseParametrs parametrs);
        SaleDTO? GetSaleById(int id);
        SaleDTO CreateSale(SaleForCreateDTO saleForCreate);
        void UpdateSale(SaleForUpdateDTO saleForUpdate);
        void DeleteSale(int id);
    }
}
