using DiyorMarket.Domain.Common;

namespace DiyorMarket.Domain.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }=string.Empty;
        public int NumberOfProducts { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
