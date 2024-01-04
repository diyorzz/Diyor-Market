using DiyorMarket.Domain.DTOs.Sale;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;

namespace DiyorMarket.Domain.Enterfaces.Services
{
    public interface ISaleService
    {
        PaginatedList<SaleDTOs> Getsales(SaleResourseParametrs parametrs);
        SaleDTOs? GetSaleById(int id);
        SaleDTOs CreateSale(SaleForCreateDTOs saleForCreate);
        void UpdateSale(SaleForUpdateDTOs saleForUpdate);
        void DeleteSale(int id);
    }
}
