
namespace DiyorMarket.Domain.DTOs.SaleItam
{
    public record SaleItemDTOs(
        int Id,
        int Quantity,
        decimal UnitPrice,
        int ProductId,
        int SaleId
        );
}
