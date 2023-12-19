using DiyorMarket.Domain.DTOs.SaleItam;

namespace DiyorMarket.Domain.DTOs.Sale
{
    public record SaleDTOs(
        int Id,
        DateTime SaleDate,
        int CustomerId,
        ICollection<SaleItemDTOs> SaleItems
        );
}
