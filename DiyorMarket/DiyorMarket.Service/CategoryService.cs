using AutoMapper;
using DiyorMarket.Domain.DTOs.Category;
using DiyorMarket.Domain.Enterfaces.Repositories;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Entities;
using DiyorMarket.Domain.Exceptions;
using Microsoft.Extensions.Logging;


namespace DiyorMarket.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICommonRepository _repository;
        private readonly ILogger<CategoryService> _logger;
        public CategoryService(IMapper mapper, ICommonRepository repository, ILogger<CategoryService> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
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

            if(category == null)
            {
                throw new EntityNotFoundException($"Category with id. {id} not found.");
            }

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
