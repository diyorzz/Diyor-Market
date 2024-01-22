using AutoMapper;
using DiyorMarket.Domain.DTOs.Sale;
using DiyorMarket.Domain.Entities;

namespace DiyorMarket.Domain.Mappings
{
    public class SaleMappings : Profile
    {
        public SaleMappings()
        {
            CreateMap<SaleDTO, Sale>();
            CreateMap<Sale, SaleDTO>();
            CreateMap<SaleForCreateDTO, Sale>();
            CreateMap<SaleForUpdateDTO, Sale>();
        }
    }
}
