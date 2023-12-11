using DiyorMarket.Domain.DTOs.Category;
using DiyorMarket.Domain.Enterfaces.Services;
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
        public ActionResult<IEnumerable<CategoryDto>> Get()
        {
            try
            {
                var categories= _categoryService.GetCategories();
                return Ok(categories);
            }
            catch(Exception ex)
            {
                return StatusCode(500,
                    $"There was error returning categories.{ex.Message}");
            }

        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public ActionResult<CategoryDto> Get(int id)
        {
            try
            {
                var categories = _categoryService.GetCategoryById(id);
                if(categories == null)
                {
                    return NotFound($"Category with id {id} does not exist.");
                }
                return Ok(categories);
            }
            catch(Exception ex)
            {
                return StatusCode(500,
                    $"There was error returning categories.{ex.Message}");
            }
         
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public ActionResult<CategoryDto> Post([FromBody] CategoryForCreateDto categoryForCreateDto)
        {
            try
            {
                var createCategory = _categoryService.CreateCategory(categoryForCreateDto);
                
                return Ok(createCategory);
            }
            catch(Exception ex)
            {
                return StatusCode(500,
                    $"There was error returning categories.");
            }
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public ActionResult Put([FromRoute]int id, [FromBody] CategoryForUpdateDto category)
        {
            if (id != category.Id)
            {
                return BadRequest(
                    $"Route id:{id} does not match with parametr id {category.Id}");
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

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _categoryService.DeleteCategory(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500,
                    $"There was an error deleting category with id: {id}. {ex.Message}");
            }
        }
    }
}
