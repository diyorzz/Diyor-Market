
namespace DiyorMarket.Domain.DTOs.Customer
{
    public record CustomerForUpdateDTOs(
        int Id,
        string FirstName,
        string LastName,
        string PhoneNumber
        );
}
