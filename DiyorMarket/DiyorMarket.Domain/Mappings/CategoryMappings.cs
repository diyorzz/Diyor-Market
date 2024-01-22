using AutoMapper;
using DiyorMarket.Domain.DTOs.Category;
using DiyorMarket.Domain.Entities;

namespace DiyorMarket.Domain.Mappings
{
    public class CategoryMappings : Profile
    {
        public CategoryMappings()
        {
            CreateMap<Category, CategoryDTO>()
            //.ForMember(x => x.NumberOfProducts, t => t.MapFrom(p => p.Products.Count));
            .ForCtorParam(nameof(Category.NumberOfProducts),
                    opt => opt.MapFrom(src => src.Products.Count()));
            CreateMap<CategoryDTO, Category>();
            CreateMap<CategoryForCreateDTO, Category>();
            CreateMap<CategoryForUpdateDto, Category>();
        }
    }
}
