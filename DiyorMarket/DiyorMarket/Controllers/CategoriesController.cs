using DiyorMarket.Domain.DTOs.Category;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiyorMarket.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> GetCategories()
        {
            try
            {
                var categories = _categoryService.GetCategories();

                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    $"There was error returning categories. {ex.Message}");
            }
        }

        [HttpGet("{id}", Name = "GetCategoryById")]
        public ActionResult<CategoryDto> GetCategoryById(int id)
        {
            try
            {
                var category = _categoryService.GetCategoryById(id);

                if (category is null)
                {
                    return NotFound($"Category with id: {id} does not exist.");
                }

                return Ok(category);
            }
            catch (EntityNotFoundException)
            {
                return NotFound($"Product with id: {id} not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    $"There was error getting category with id: {id}. {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult<CategoryDto> CreateCategory([FromBody]CategoryForCreateDto category)
        {
            try
            {
                var createdCategory = _categoryService.CreateCategory(category);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    $"There was an error creating new category. {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCategory([FromRoute] int id, [FromBody] CategoryForUpdateDto category)
        {
            if (id != category.Id)
            {
                return BadRequest(
                    $"Route id: {id} does not match with parameter id: {category.Id}.");
            }

            try
            {
                _categoryService.UpdateCategory(category);

                return NoContent();
            }
            catch (Exception ex)
            {

                return StatusCode(500,
                    $"There was an error updating category with id: {id}. {ex.Message}");

            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCategoryAsync(int id)
        {
            try
            {
                _categoryService.DeleteCategory(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    $"There was an error deleting category with id: {id}. {ex.Message}");
            }
        }
    }
}
