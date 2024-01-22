namespace DiyorMarket.Domain.DTOs.Supplier
{
    public record SupplierForCreateDTO(
        string FirstName,
        string LastName,
        string PhoneNumber,
        string Company
        );
}
