using DiyorMarket.Domain.DTOs.Product;

namespace DiyorMarket.Domain.DTOs.Category
{
    public record CategoryDTOs
    (
        int Id,
        string Name,
        int NumberOfProducts,
    ICollection<ProductDto> Products);
}
