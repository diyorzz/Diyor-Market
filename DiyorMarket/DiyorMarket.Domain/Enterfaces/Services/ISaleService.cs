using DiyorMarket.Domain.DTOs.Sale;

namespace DiyorMarket.Domain.Enterfaces.Services
{
    public interface ISaleService
    {
        IEnumerable<SaleDTOs> Getsales();
        SaleDTOs? GetSaleById(int id);
        SaleDTOs CreateSale(SaleForCreateDTOs saleForCreate);
        void UpdateSale(SaleForUpdateDTOs saleForUpdate);
        void DeleteSale(int id);
    }
}
