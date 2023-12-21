using DiyorMarket.Domain.DTOs.Product;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;

namespace DiyorMarket.Domain.Enterfaces.Services
{
    public interface IProductService
    {
        PaginatedList<ProductDto> GetProducts(ProductResourceParameters parameters);
        ProductDto? GetProductById(int id);
        ProductDto CreateProduct(ProductForCreateDTOs productForCreate);
        void UpdateProduct(ProductForUpdateDTOs productForUpdate);
        void DeleteProduct(int id);
    }
}
