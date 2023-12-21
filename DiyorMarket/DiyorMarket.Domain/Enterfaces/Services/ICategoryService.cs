using DiyorMarket.Domain.DTOs.Category;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;

namespace DiyorMarket.Domain.Enterfaces.Services
{
    public interface ICategoryService
    {
        PaginatedList<CategoryDTOs> GetCategories(CategoryResourseParametrs parametrs);
        CategoryDTOs? GetCategoryById(int id);
        CategoryDTOs CreateCategory(CategoryForCreateDto category);
        void UpdateCategory(CategoryForUpdateDto category); 
        void DeleteCategory(int id);
    }
}
