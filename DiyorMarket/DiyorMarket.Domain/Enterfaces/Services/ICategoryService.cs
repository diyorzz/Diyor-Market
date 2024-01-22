using DiyorMarket.Domain.DTOs.Category;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;

namespace DiyorMarket.Domain.Enterfaces.Services
{
    public interface ICategoryService
    {
        PaginatedList<CategoryDTO> GetCategories(CategoryResourseParametrs parametrs);
        CategoryDTO? GetCategoryById(int id);
        CategoryDTO CreateCategory(CategoryForCreateDTO category);
        void UpdateCategory(CategoryForUpdateDto category); 
        void DeleteCategory(int id);
    }
}
