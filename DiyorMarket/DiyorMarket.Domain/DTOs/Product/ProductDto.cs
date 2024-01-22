using DiyorMarket.Domain.DTOs.SaleItam;
using DiyorMarket.Domain.DTOs.SupplyItem;

namespace DiyorMarket.Domain.DTOs.Product
{
    public record ProductDTO(
        int Id,
        string Name,
        string Description,
        decimal Price,
        DateTime ExpireDate,
        int CategoryId,
        ICollection<SaleItemDTO> SaleItems,
        ICollection<SupplyItemDTOs> SupplyItems);
}
