using AutoMapper;
using DiyorMarket.Domain.DTOs.Category;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Entities;
using DiyorMarket.Domain.Exceptions;
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

        public CategoryDTOs CreateCategory(CategoryForCreateDto category)
        {
            var categoryEntity=_mapper.Map<Category>(category);

            _context.Categories.Add(categoryEntity);
            _context.SaveChanges();

             return _mapper.Map<CategoryDTOs>(categoryEntity);
        }

        public void DeleteCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == id);
            if(category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
        public IEnumerable<CategoryDTOs> GetCategories()
        {
            var categories = _context.Categories.ToList();

            return _mapper.Map<IEnumerable<CategoryDTOs>>(categories);
        }

        public CategoryDTOs? GetCategoryById(int id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == id);

            if (category is null)
            {
                throw new EntityNotFoundException($"Category with id: {id} not found");
            }

            return _mapper.Map<CategoryDTOs>(category);      
        }

        public void UpdateCategory(CategoryForUpdateDto category)
        {
            var categoryEntity = _mapper.Map<Category>(category);

            _context.Categories.Update(categoryEntity);
            _context.SaveChanges();
        }
    }
}
