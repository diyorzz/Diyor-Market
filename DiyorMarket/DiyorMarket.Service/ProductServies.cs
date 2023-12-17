using AutoMapper;
using DiyorMarket.Domain.DTOs.Product;
using DiyorMarket.Domain.Enterfaces.Repositories;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace DiyorMarket.Service
{
    public class ProductServies : IProductService
    {
        private readonly IMapper _mapper;
        private readonly ICommonRepository _repository;


        public ProductServies(IMapper mapper, ICommonRepository repository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public IEnumerable<ProductDto> GetProducts(/*ProductResourceParameters productResourceParameters*/)
        {
            //var query = _context.Products.AsQueryable();

            //if (productResourceParameters.CategoryId is not null)
            //{
            //    query = query.Where(x => x.CategoryId == productResourceParameters.CategoryId);
            //}

            //if (!string.IsNullOrWhiteSpace(productResourceParameters.SearchString))
            //{
            //    query = query.Where(x => x.Name.Contains(productResourceParameters.SearchString)
            //    || x.Description.Contains(productResourceParameters.SearchString));
            //}

            //if (productResourceParameters.Price is not null)
            //{
            //    query = query.Where(x => x.Price == productResourceParameters.Price);
            //}

            //if (productResourceParameters.PriceLessThan is not null)
            //{
            //    query = query.Where(x => x.Price < productResourceParameters.PriceLessThan);
            //}

            //if (productResourceParameters.PriceGreaterThan is not null)
            //{
            //    query = query.Where(x => x.Price > productResourceParameters.PriceGreaterThan);
            //}

            //var products = query.ToList();

            //var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);

            //return productDtos;
            return null;
        }

        public ProductDto? GetProductById(int id)
        {

            var product = _repository.Product.FindById(id);

            var productDto = _mapper.Map<ProductDto>(product);

            return productDto;
        }

        public ProductDto CreateProduct(ProductForCreateDTOs productForCreate)
        {
            var productEntity = _mapper.Map<Product>(productForCreate);

            _repository.Product.Create(productEntity);
            _repository.SaveChanges();

            var productDto = _mapper.Map<ProductDto>(productEntity);

            return productDto;
        }

        public void UpdateProduct(ProductForUpdateDTOs productForUpdate)
        {
            var productEntity = _mapper.Map<Product>(productForUpdate);

            _repository.Product.Update(productEntity);

            _repository.SaveChanges();

        }

        public void DeleteProduct(int id)
        {
            _repository.Product.Delete(id);
            _repository.SaveChanges();
        }
    }
}
