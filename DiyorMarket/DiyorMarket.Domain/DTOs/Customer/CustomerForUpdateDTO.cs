namespace DiyorMarket.Domain.DTOs.Customer
{
    public record CustomerForUpdateDTO(
        int Id,
        string FirstName,
        string LastName,
        string PhoneNumber
        );
}
