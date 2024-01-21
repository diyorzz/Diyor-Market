namespace DiyorMarket.Domain.DTOs.Sale
{
    public record SaleDTOs(
        int Id,
        DateTime SaleDate,
        int CustomerId
        );
}
