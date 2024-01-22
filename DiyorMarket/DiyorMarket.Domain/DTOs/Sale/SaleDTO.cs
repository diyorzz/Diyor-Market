namespace DiyorMarket.Domain.DTOs.Sale
{
    public record SaleDTO(
        int Id,
        DateTime SaleDate,
        int CustomerId
        );
}
