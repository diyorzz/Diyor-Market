using DiyorMarket.Domain.DTOs.SupplyItem;

namespace DiyorMarket.Domain.DTOs.Supply
{
    public class SupplyDTOs
    {
        public int Id { get; set; }
        public DateTime SupplyDate { get; set; }
        public int SupplierId { get; set; }
        public virtual ICollection<SupplyItemDTOs> SupplItems { get; set; }
    }
}
