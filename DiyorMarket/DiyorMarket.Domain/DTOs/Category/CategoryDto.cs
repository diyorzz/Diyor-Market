using DiyorMarket.Domain.DTOs.Product;

namespace DiyorMarket.Domain.DTOs.Category
{
    public record CategoryDTO
    (
        int Id,
        string Name,
        int NumberOfProducts,
    ICollection<ProductDTO> Products);
}
