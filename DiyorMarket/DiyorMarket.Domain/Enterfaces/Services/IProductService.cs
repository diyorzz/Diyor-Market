using DiyorMarket.Domain.DTOs.Product;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;

namespace DiyorMarket.Domain.Enterfaces.Services
{
    public interface IProductService
    {
        PaginatedList<ProductDTO> GetProducts(ProductResourceParameters parameters);
        ProductDTO? GetProductById(int id);
        ProductDTO CreateProduct(ProductForCreateDTO productForCreate);
        void UpdateProduct(ProductForUpdateDTO productForUpdate);
        void DeleteProduct(int id);
    }
}
