using DiyorMarket.Domain.DTOs.Category;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public ActionResult<IEnumerable<CategoryDTOs>> GetCategories([FromQuery] CategoryResourseParametrs category)
        {
            var categories = _categoryService.GetCategories(category);

            var metaData = GetPaginationMetaData(categories);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));

            return Ok(categories);
        }

        [HttpGet("{id}", Name = "GetCategoryById")]
        public ActionResult<CategoryDTOs> GetCategoryById(int id)
        {
            var category = _categoryService.GetCategoryById(id);

            return Ok(category);
        }

        [HttpPost]
        public ActionResult<CategoryDTOs> CreateCategory([FromBody] CategoryForCreateDto category)
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
        private PagenationMetaData GetPaginationMetaData(PaginatedList<CategoryDTOs> customerDtOs)
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
