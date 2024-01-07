using DiyorMarket.Domain.DTOs.SaleItam;
using DiyorMarket.Domain.DTOs.SupplyItem;

namespace DiyorMarket.Domain.DTOs.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime ExpireDate { get; set; }
        public int CategoryId { get; set; }
        public ICollection<SaleItemDTos> SaleItems { get; set; } = new List<SaleItemDTos>();
        public ICollection<SupplyItemDTOs> SupplyItems { get; set; } = new List<SupplyItemDTOs>();
    }
        
}
