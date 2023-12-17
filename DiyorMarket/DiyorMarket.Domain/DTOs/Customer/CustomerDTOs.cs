using DiyorMarket.Domain.DTOs.Sale;

namespace DiyorMarket.Domain.DTOs.Customer
{
    public record CustomerDtOs(
        int Id,
        string FirstName,
        string LastName,
        DateTime DateOfBirth,
        string PhoneNumber,
        string Email,
        ICollection<SaleDTOs> Sales
        );
}
