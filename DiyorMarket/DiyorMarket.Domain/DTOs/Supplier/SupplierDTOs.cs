namespace DiyorMarket.Domain.DTOs.Supplier
{
    //public class SupplierDTOs
    //{
    //    public int Id { get; set; }
    //    public string FullName { get; set; }
    //    public string PhoneNumber { get; set; }
    //}
    public record SupplierDTOs(
        int Id,
        string FullName,
        string PhoneNumber);
}
