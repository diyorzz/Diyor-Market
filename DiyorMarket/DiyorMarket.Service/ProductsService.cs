using AutoMapper;
using DiyorMarket.Domain.DTOs.Product;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Entities;
using DiyorMarket.Domain.Exceptions;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;
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
        public PaginatedList<ProductDto> GetProducts(ProductResourceParameters parameters)
        {
            var query = _context.Products.AsQueryable();

            if (parameters.CategoryId is not null)
            {
                query = query.Where(x => x.CategoryId == parameters.CategoryId);
            }

            if (!string.IsNullOrWhiteSpace(parameters.SearchString))
            {
                query = query.Where(x => x.Name.Contains(parameters.SearchString)
                    || x.Description.Contains(parameters.SearchString));
            }

            if (parameters.Price is not null)
            {
                query = query.Where(x => x.Price == parameters.Price);
            }

            if (parameters.PriceLessThan is not null)
            {
                query = query.Where(x => x.Price < parameters.PriceLessThan);
            }

            if (parameters.PriceGraterThan is not null)
            {
                query = query.Where(x => x.Price > parameters.PriceGraterThan);
            }

            if (!string.IsNullOrEmpty(parameters.OrderBy))
            {
                query = parameters.OrderBy.ToLowerInvariant() switch
                {
                    "name" => query.OrderBy(x => x.Name),
                    "namedesc" => query.OrderByDescending(x => x.Name),
                    "description" => query.OrderBy(x => x.Description),
                    "descriptiondesc" => query.OrderByDescending(x => x.Description),
                    "price" => query.OrderBy(x => x.Price),
                    "pricedesc" => query.OrderByDescending(x => x.Price),
                    "expiredate" => query.OrderBy(x => x.ExpireDate),
                    "expiredatedesc" => query.OrderByDescending(x => x.ExpireDate),
                    _ => query.OrderBy(x => x.Name),
                };
            }

            var products = query.ToPaginatedList(parameters.Pagesize, parameters.PageNumber);

            var productDTO = _mapper.Map<List<ProductDto>>(products);

            return new PaginatedList<ProductDto>(productDTO, products.TotalCount, products.CurrentPage, products.PageSize);
        }
        public ProductDto? GetProductById(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product is null)
            {
                throw new EntityNotFoundException($"Product with id: {id} not found");
            }

            return _mapper.Map<ProductDto?>(product);
        }
        public ProductDto CreateProduct(ProductForCreateDTOs productForCreate)
        {
            var product = _mapper.Map<Product>(productForCreate);

            _context.Products.Add(product);
            _context.SaveChanges();

            return _mapper.Map<ProductDto>(product);
        }
        public void UpdateProduct(ProductForUpdateDTOs productForUpdate)
        {
            var product = _mapper.Map<Product>(productForUpdate);

            _context.Products.Update(product);
            _context.SaveChanges();
        }
        public void DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product is not null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}
