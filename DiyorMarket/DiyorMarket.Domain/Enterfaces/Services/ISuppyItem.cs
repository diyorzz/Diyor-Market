using DiyorMarket.Domain.DTOs.Category;
using DiyorMarket.Domain.DTOs.SupplyItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
