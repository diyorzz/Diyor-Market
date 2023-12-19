
namespace DiyorMarket.Domain.DTOs.SaleItam
{
    public record SaleItemForCreateDTOs(
         int Quantity,
         decimal UnitPrice,
         int ProductId,
         int SaleId
         );
}
