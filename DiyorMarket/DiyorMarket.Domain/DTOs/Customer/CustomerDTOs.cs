using DiyorMarket.Domain.DTOs.Sale;

namespace DiyorMarket.Domain.DTOs.Customer
{
    public record CustomerDtOs(
        int Id,
        string FirstName,
        string LastName,
        string PhoneNumber,
        ICollection<SaleDTOs> Sales
        );
}
