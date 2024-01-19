using DiyorMarket.Domain.DTOs.Sale;

namespace DiyorMarket.Domain.DTOs.Customer
{
    //public class CustomerDTOs
    //{
    //    public int Id { get; set; }
    //    public string FullName { get; set; }
    //    public string PhoneNumber { get; set; }
    //    public virtual ICollection<SaleDTOs> Sales { get; set; }
    //}
    public record CustomerDTOs(
        int Id,
        string FullName,
        string PhoneNumber,
        ICollection<SaleDTOs> Sales
        );
}
