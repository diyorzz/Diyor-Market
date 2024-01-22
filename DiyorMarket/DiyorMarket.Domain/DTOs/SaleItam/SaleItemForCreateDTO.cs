namespace DiyorMarket.Domain.DTOs.SaleItam
{
    public record SaleItemForCreateDTO(
         int Quantity,
         decimal UnitPrice,
         int ProductId,
         int SaleId
         );
}
