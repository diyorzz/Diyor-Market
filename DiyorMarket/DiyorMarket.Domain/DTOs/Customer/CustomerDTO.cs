using DiyorMarket.Domain.DTOs.Sale;

namespace DiyorMarket.Domain.DTOs.Customer
{
    public record CustomerDTO(
        int Id,
        string FullName,
        string PhoneNumber,
        ICollection<SaleDTO> Sales
        );
}
