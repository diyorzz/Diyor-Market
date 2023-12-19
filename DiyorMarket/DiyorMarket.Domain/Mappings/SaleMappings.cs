using AutoMapper;
using DiyorMarket.Domain.DTOs.Sale;
using DiyorMarket.Domain.Entities;

namespace DiyorMarket.Domain.Mappings
{
    public class SaleMappings : Profile
    {
        public SaleMappings()
        {
            CreateMap<SaleDTOs, Sale>();
            CreateMap<Sale, SaleDTOs>();
            CreateMap<SaleForCreateDTOs, Sale>();
            CreateMap<SaleForUpdateDTOs, Sale>();
        }
    }
}
