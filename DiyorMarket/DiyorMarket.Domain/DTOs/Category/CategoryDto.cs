using DiyorMarket.Domain.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyorMarket.Domain.DTOs.Category
{
    public record CategoryDto(
        int Id,
        string Name,
        int NumberOfProducts,
        ICollection<ProductDto>Products);
}
