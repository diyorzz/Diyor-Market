using DiyorMarket.Domain.DTOs.Category;

namespace DiyorMarket.Domain.Enterfaces.Services
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDTOs> GetCategories();
        CategoryDTOs? GetCategoryById(int id);
        CategoryDTOs CreateCategory(CategoryForCreateDto category);
        void UpdateCategory(CategoryForUpdateDto category); 
        void DeleteCategory(int id);
    }
}
