using AutoMapper;
using DiyorMarket.Domain.DTOs.Category;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Entities;
using DiyorMarket.Domain.Exceptions;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;
using DiyorMarket.Infrastructure.Persistence;

namespace DiyorMarket.Services
{
    public class CategoriesService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly DiyorMarketDbContext _context;
        public CategoriesService(IMapper mapper, DiyorMarketDbContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public PaginatedList<CategoryDTO> GetCategories(CategoryResourseParametrs parameters)
        {
            var query = _context.Categories.AsQueryable();

            if (!string.IsNullOrWhiteSpace(parameters.SearchString))
            {
                query = query.Where(x => x.Name.Contains(parameters.SearchString));
            }
            if (!string.IsNullOrEmpty(parameters.OrderBy))
            {
                query = parameters.OrderBy.ToLowerInvariant() switch
                {
                    "name" => query.OrderBy(x => x.Name),
                    "namedesc" => query.OrderByDescending(x => x.Name),
                    _ => query.OrderBy(x => x.Id),
                };
            }
            var category = query.ToPaginatedList(parameters.Pagesize, parameters.PageNumber);

            var categryDTO = _mapper.Map<List<CategoryDTO>>(category);

            return new PaginatedList<CategoryDTO>(categryDTO, category.TotalCount, category.CurrentPage, category.PageSize);
        }
        public CategoryDTO? GetCategoryById(int id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == id);

            if (category is null)
            {
                throw new EntityNotFoundException($"Category with id: {id} not found");
            }

            return _mapper.Map<CategoryDTO>(category);
        }
        public CategoryDTO CreateCategory(CategoryForCreateDTO category)
        {
            var categoryEntity = _mapper.Map<Category>(category);

            _context.Categories.Add(categoryEntity);
            _context.SaveChanges();

            return _mapper.Map<CategoryDTO>(categoryEntity);
        }
        public void UpdateCategory(CategoryForUpdateDto category)
        {
            var categoryEntity = _mapper.Map<Category>(category);

            _context.Categories.Update(categoryEntity);
            _context.SaveChanges();
        }
        public void DeleteCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
    }
}
