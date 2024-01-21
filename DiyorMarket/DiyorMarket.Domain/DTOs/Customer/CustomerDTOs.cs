using DiyorMarket.Domain.DTOs.Sale;

namespace DiyorMarket.Domain.DTOs.Customer
{
    public record CustomerDTOs(
        int Id,
        string FullNama,
        string PhoneNumber,
        ICollection<SaleDTOs> Sales
        );
}
