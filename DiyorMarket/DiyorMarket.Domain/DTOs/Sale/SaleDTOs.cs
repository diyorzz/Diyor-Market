using DiyorMarket.Domain.DTOs.SaleItam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyorMarket.Domain.DTOs.Sale
{
    public record SaleDTOs(
        int Id,
        DateTime SaleDate,
        int CustomerId,
        ICollection<SaleItemDTOs> SaleItems
        );
}
