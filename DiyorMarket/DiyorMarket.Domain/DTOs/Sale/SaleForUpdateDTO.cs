namespace DiyorMarket.Domain.DTOs.Sale
{
    public record SaleForUpdateDTO(
        int Id,
        DateTime SaleDate,
        int CustomerId
        );
}
