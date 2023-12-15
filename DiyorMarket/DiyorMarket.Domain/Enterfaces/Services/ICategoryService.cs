using DiyorMarket.Domain.DTOs.Category;

namespace DiyorMarket.Domain.Enterfaces.Services
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetCategories();
        CategoryDto GetCategoryById(int id);
        CategoryDto CreateCategory(CategoryForCreateDto category);
        void UpdateCategory(CategoryForUpdateDto category); 
        void DeleteCategory(int id);
    }
}
