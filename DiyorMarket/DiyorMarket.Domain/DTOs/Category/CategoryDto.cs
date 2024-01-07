using DiyorMarket.Domain.DTOs.Product;

namespace DiyorMarket.Domain.DTOs.Category
{
    public class CategoryDTOs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfProducts { get; set; }
        public ICollection<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}
