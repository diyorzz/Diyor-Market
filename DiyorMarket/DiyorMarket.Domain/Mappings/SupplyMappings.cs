using AutoMapper;
using DiyorMarket.Domain.DTOs.Supply;
using DiyorMarket.Domain.Entities;

namespace DiyorMarket.Domain.Mappings
{
    public class SupplyMappings : Profile
    {
        public SupplyMappings()
        {
            CreateMap<SupplyDTO, Supply>();
            CreateMap<Supply, SupplyDTO>();
            CreateMap<SupplyForCreateDTO, Supply>();
            CreateMap<SupplyForUpdateDTO, Supply>();
        }
    }
}
