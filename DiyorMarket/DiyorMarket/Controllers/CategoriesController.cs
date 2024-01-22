using DiyorMarket.Domain.DTOs.Category;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DiyorMarket.Controllers
{
    [Route("api/categories")]
    [ApiController]
    //[Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService ?? throw new ArgumentNullException(nameof(categoryService));
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryDTO>> GetCategories([FromQuery] CategoryResourseParametrs category)
        {
            var categories = _categoryService.GetCategories(category);

            var metaData = GetPaginationMetaData(categories);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));

            return Ok(categories);
        }

        [HttpGet("{id}", Name = "GetCategoryById")]
        public ActionResult<CategoryDTO> GetCategoryById(int id)
        {
            var category = _categoryService.GetCategoryById(id);

            return Ok(category);
        }

        [HttpPost]
        public ActionResult<CategoryDTO> CreateCategory([FromBody] CategoryForCreateDTO category)
        {
            _categoryService.CreateCategory(category);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCategory([FromRoute] int id, [FromBody] CategoryForUpdateDto category)
        {
            if (id != category.Id)
            {
                return BadRequest(
                    $"Route id: {id} does not match with parameter id: {category.Id}.");
            }

            _categoryService.UpdateCategory(category);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCategoryAsync(int id)
        {
            _categoryService.DeleteCategory(id);

            return NoContent();
        }
        private PagenationMetaData GetPaginationMetaData(PaginatedList<CategoryDTO> customerDtOs)
        {
            return new PagenationMetaData
            {
                Totalcount = customerDtOs.TotalCount,
                PageSize = customerDtOs.PageSize,
                CurrentPage = customerDtOs.CurrentPage,
                TotalPages = customerDtOs.TotalPages,
            };
        }
    }
}
