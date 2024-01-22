namespace DiyorMarket.Domain.DTOs.Supplier
{
    public record SupplierForUpdateDTO(
        int Id,
        string FirstName,
        string LastName,
        string PhoneNumber,
        string Company
        );
}
