using AutoMapper;
using DiyorMarket.Domain.DTOs.Category;
using DiyorMarket.Domain.DTOs.Product;
using DiyorMarket.Domain.Enterfaces.Repositories;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Entities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyorMarket.Service
{
    public class ProductServies : IProductService
    {
        private readonly IMapper _mapper;
        private readonly ICommonRepository _repository;
        private readonly ILogger _logger;


        public ProductServies(IMapper mapper, ICommonRepository repository, ILogger logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            try
            {
                var product = _repository.Product.FindAll();

                var productDtos = _mapper.Map<IEnumerable<ProductDto>>(product);

                return productDtos;
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.Error($"There was an error mapping between Product and ProductDTO", ex.Message);
                throw;
            }
            catch (DbException ex)
            {
                _logger.Error("Database error occured while fetching products.", ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.Error("Something went wrong while fetching products.", ex.Message);
                throw;
            }
        }

        public ProductDto? GetProductById(int id)
        {
            try
            {
                var product = _repository.Product.FindById(id);

                var productDto = _mapper.Map<ProductDto>(product);

                return productDto;
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.Error($"There was an error mapping between Product and ProductDto", ex.Message);
                throw;
            }
            catch (DbException ex)
            {
                _logger.Error($"Database error occured while fetching product with id: {id}.", ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong while fetching product with id: {id}.", ex.Message);
                throw;
            }
        }

        public ProductDto CreateProduct(ProductForCreateDTOs productForCreate)
        {
            try
            {
                var productEntity = _mapper.Map<Product>(productForCreate);

                var createdProduct = _repository.Product.Create(productEntity);
                _repository.SaveChanges();

                var productDto = _mapper.Map<ProductDto>(productEntity);

                return productDto;
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.Error($"There was an error mapping between product and productDto", ex.Message);
                throw;
            }
            catch (DbException ex)
            {
                _logger.Error("Database error occured while creating new product.", ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.Error("Something went wrong while creating new product.", ex.Message);
                throw;
            }
        }

        public void UpdateProduct(ProductForUpdateDTOs productForUpdate)
        {
            try
            {
                var productEntity = _mapper.Map<Product>(productForUpdate);

                _repository.Product.Update(productEntity);

                _repository.SaveChanges();
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.Error($"There was an error mapping betweenproduct and ProductDto", ex.Message);
                throw;
            }
            catch (DbException ex)
            {
                _logger.Error("Database error occured while updating product.", ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.Error("Something went wrong while updating product.", ex.Message);
                throw;
            }
        }

        public void DeleteProduct(int id)
        {
            try
            {
                _repository.Product.Delete(id);
                _repository.SaveChanges();
            }
            catch (DbException ex)
            {
                _logger.Error($"Database error occured while deleting product with id: {id}.", ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                _logger.Error($"Something went wrong while deleting product with id: {id}.", ex.Message);
                throw;
            }
        }
    }
}
