namespace DiyorMarket.Domain.DTOs.SaleItam
{
    public record SaleItemForUpdateDTOs(
        int Id,
        int Quantity,
        decimal UnitPrice,
        int ProductId,
        int SaleId
        );
}
