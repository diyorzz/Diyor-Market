using DiyorMarket.Domain.DTOs.Category;
using DiyorMarket.Domain.DTOs.Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
