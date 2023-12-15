using AutoMapper;
using DiyorMarket.Domain.DTOs.Category;
using DiyorMarket.Domain.Enterfaces.Repositories;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            try
            {
                var categoryEntity = _mapper.Map<Category>(category);
                _repository.Category.Create(categoryEntity);
                _repository.SaveChanges();

                return _mapper.Map<CategoryDto>(categoryEntity);
                    
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"database error creating new category", ex);
                throw;
            }
            catch(Exception ex) 
            {
                _logger.LogError("Error creating new category", ex);
                throw;
            }
        }

        public void DeleteCategory(int id)
        {
            try
            {
                _repository.Category.Delete(id);
                _repository.SaveChanges();

            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"database error deleting  category with id: {id}", ex);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting  category with id: {id}", ex);
                throw;
            }
        }

        public IEnumerable<CategoryDto> GetCategories()
        {
            try
            {
                var categories=_repository.Category.FindAll();

                var categoryDTOs=_mapper.Map<IEnumerable<CategoryDto>>(categories);

                return categoryDTOs;


            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Database error fetching categories", ex);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error fatching categories", ex);
                throw;
            }
        }

        public CategoryDto GetCategoryById(int id)
        {
            try
            {
                var category = _repository.Category.FindById(id);

                var categoryDTOs = _mapper.Map<CategoryDto>(category);

                return categoryDTOs;


            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"database error fetching category with id: {id}", ex);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fatching category with id: {id}", ex);
                throw;
            }
        }

        public void UpdateCategory(CategoryForUpdateDto category)
        {
            try
            {
                var categoryEntity = _mapper.Map<Category>(category);

                _repository.Category.Update(categoryEntity);
                _repository.SaveChanges();

            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"database error updating category with id: {category.Id}.", ex);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating category with id: {category.Id}.", ex);
                throw;
            }
        }
    }
}
