using AutoMapper;
using DiyorMarket.Domain.DTOs.Category;
using DiyorMarket.Domain.Enterfaces.Repositories;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Entities;


namespace DiyorMarket.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICommonRepository _repository;

        public CategoryService(IMapper mapper, ICommonRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public CategoryDto CreateCategory(CategoryForCreateDto category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            _repository.Category.Create(categoryEntity);
            _repository.SaveChanges();

            return _mapper.Map<CategoryDto>(categoryEntity);
        }

        public void DeleteCategory(int id)
        {
            _repository.Category.Delete(id);
            _repository.SaveChanges();
        }

        public IEnumerable<CategoryDto> GetCategories()
        {
            var categories = _repository.Category.FindAll();

            var categoryDTOs = _mapper.Map<IEnumerable<CategoryDto>>(categories);

            return categoryDTOs;
        }

        public CategoryDto GetCategoryById(int id)
        {
            var category = _repository.Category.FindById(id);

            var categoryDTOs = _mapper.Map<CategoryDto>(category);

            return categoryDTOs;
        }

        public void UpdateCategory(CategoryForUpdateDto category)
        {
            var categoryEntity = _mapper.Map<Category>(category);

            _repository.Category.Update(categoryEntity);
            _repository.SaveChanges();
        }
    }
}
