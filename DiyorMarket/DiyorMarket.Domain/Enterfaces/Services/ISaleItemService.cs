using DiyorMarket.Domain.DTOs.Category;
using DiyorMarket.Domain.DTOs.SaleItam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
