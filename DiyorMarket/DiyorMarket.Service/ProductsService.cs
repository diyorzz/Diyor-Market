using AutoMapper;
using DiyorMarket.Domain.DTOs.Product;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Entities;
using DiyorMarket.Domain.Exceptions;
using DiyorMarket.Infrastructure.Persistence;

namespace DiyorMarket.Services
{
    public class ProductsService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly DiyorMarketDbContext _context;
        public ProductsService(IMapper mapper, DiyorMarketDbContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public ProductDto CreateProduct(ProductForCreateDTOs productForCreate)
        {
            var product = _mapper.Map<Product>(productForCreate);

            _context.Products.Add(product);
            _context.SaveChanges();

            return _mapper.Map<ProductDto>(product);
        }
        public void DeleteProduct(int id)
        {
            var product= _context.Products.FirstOrDefault(p => p.Id == id);

            if(product is not null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
        public ProductDto? GetProductById(int id)
        {
            var product=_context.Products.FirstOrDefault(p => p.Id == id);

            if( product is null)
            {
                throw new EntityNotFoundException($"Product with id: {id} not found");
            }

            return _mapper.Map<ProductDto?>(product);
        }
        public IEnumerable<ProductDto> GetProducts()
        {
            var products = _context.Products.ToList();

            return _mapper.Map<IEnumerable<ProductDto>>(products);  
        }
        public void UpdateProduct(ProductForUpdateDTOs productForUpdate)
        {
            var product = _mapper.Map<Product>(productForUpdate);

            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}
