    using DiyorMarket.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyorMarket.Domain.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }=string.Empty;
        public int NumberOfProducts { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
