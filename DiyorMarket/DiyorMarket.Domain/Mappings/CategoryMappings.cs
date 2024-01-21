using AutoMapper;
using DiyorMarket.Domain.DTOs.Category;
using DiyorMarket.Domain.Entities;

namespace DiyorMarket.Domain.Mappings
{
    public class CategoryMappings : Profile
    {
        public CategoryMappings()
        {
            CreateMap<Category, CategoryDTOs>()
            .ForMember(x => x.NumberOfProducts, t => t.MapFrom(p => p.Products.Count));
            CreateMap<CategoryDTOs, Category>();
            CreateMap<CategoryForCreateDto, Category>();
            CreateMap<CategoryForUpdateDto, Category>();
        }
    }
}
