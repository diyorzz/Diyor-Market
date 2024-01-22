namespace DiyorMarket.Domain.DTOs.Sale
{
    public record SaleForCreateDTO(
        DateTime SaleDate,
        int CustomerId
        );
}
