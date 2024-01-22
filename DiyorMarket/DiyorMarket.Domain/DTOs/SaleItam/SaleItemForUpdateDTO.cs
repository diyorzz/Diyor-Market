namespace DiyorMarket.Domain.DTOs.SaleItam
{
    public record SaleItemForUpdateDTO(
        int Id,
        int Quantity,
        decimal UnitPrice,
        int ProductId,
        int SaleId
        );
}
