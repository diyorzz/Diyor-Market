namespace DiyorMarket.Domain.DTOs.SaleItam
{
    public record SaleItemDTO(
        int Id,
        int Quantity,
        decimal UnitPrice,
        int ProductId,
        int SaleId
        );
}
