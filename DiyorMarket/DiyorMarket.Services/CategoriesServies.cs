using AutoMapper;
using DiyorMarket.Domain.DTOs.Category;
using DiyorMarket.Domain.Enterfaces.Repositories;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace DiyorMarket.Services
{
    public class CategoriesServies : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICommonRepository _repository;
        private readonly ILogger _logger;

        public CategoriesServies(IMapper mapper, ICommonRepository repository, ILogger logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public CategoryDto CreateCategory(CategoryForCreateDto categoryToCreate)
        {
           
                var categoryEntity = _mapper.Map<Category>(categoryToCreate);

                var createdCategory = _repository.Category.Create(categoryEntity);

                _repository.SaveChanges();

                var categoryDto = _mapper.Map<CategoryDto>(createdCategory);

                return categoryDto;
        }
        public void DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CategoryDto> GetCategories()
        {
            throw new NotImplementedException();
        }

        public CategoryDto? GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(CategoryForUpdateDto categoryToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
