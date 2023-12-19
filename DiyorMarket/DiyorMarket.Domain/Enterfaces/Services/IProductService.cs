using DiyorMarket.Domain.DTOs.Product;

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
