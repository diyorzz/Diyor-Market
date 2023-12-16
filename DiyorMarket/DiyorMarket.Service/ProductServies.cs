using AutoMapper;
using DiyorMarket.Domain.DTOs.Product;
using DiyorMarket.Domain.Enterfaces.Repositories;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Entities;
using Microsoft.Extensions.Logging;


namespace DiyorMarket.Service
{
    public class ProductServies : IProductService
    {
        private readonly IMapper _mapper;
        private readonly ICommonRepository _repository;
        private readonly ILogger<ProductServies> _logger;


        public ProductServies(IMapper mapper, ICommonRepository repository, ILogger<ProductServies> logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            var product = _repository.Product.FindAll();

            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(product);

            return productDtos;
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

            var createdProduct = _repository.Product.Create(productEntity);
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
