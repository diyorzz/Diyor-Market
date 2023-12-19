using AutoMapper;
using DiyorMarket.Domain.DTOs.SupplyItem;
using DiyorMarket.Domain.Entities;

namespace DiyorMarket.Domain.Mappings
{
    public class SupplyItemMappings : Profile
    {
        public SupplyItemMappings()
        {
            CreateMap<SupplyItemDTOs, SupplyItem>();
            CreateMap<SupplyItem, SupplyItemDTOs>();
            CreateMap<SupplyItemForCreateDTOs, SupplyItem>();
            CreateMap<SupplyItemForUpdateDTOs, SupplyItem>();
        }
    }
}
