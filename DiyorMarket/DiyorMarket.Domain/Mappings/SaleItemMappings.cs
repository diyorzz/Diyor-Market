using AutoMapper;
using DiyorMarket.Domain.DTOs.SaleItam;
using DiyorMarket.Domain.Entities;

namespace DiyorMarket.Domain.Mappings
{
    public class SaleItemMappings : Profile
    {
        public SaleItemMappings()
        {
            CreateMap<SaleItemDTOs, SaleItem>();
            CreateMap<SaleItem, SaleItemDTOs>();
            CreateMap<SaleItemForCreateDTOs, SaleItem>();
            CreateMap<SaleItemForUpdateDTOs, SaleItem>();
        }
    }
}
