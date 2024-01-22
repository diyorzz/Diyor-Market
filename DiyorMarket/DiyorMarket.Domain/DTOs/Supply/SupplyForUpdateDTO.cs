namespace DiyorMarket.Domain.DTOs.Supply
{
    public record SupplyForUpdateDTO(
        int Id,
        DateTime SupplyDate,
        int SupplierId
        );
}
