using DiyorMarket.Domain.DTOs.Category;
using DiyorMarket.Domain.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyorMarket.Domain.Enterfaces.Services
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetProducts();
        ProductDto? GetProductById(int id);
        ProductDto CreateProduct(ProductForCreateDTOs productForCreate);
        void UpdateProduct(ProductForUpdateDTOs productForUpdate);
        void DeleteProduct(int id);
    }
}
