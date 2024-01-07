using AutoMapper;
using DiyorMarket.Domain.DTOs.SaleItam;
using DiyorMarket.Domain.Entities;

namespace DiyorMarket.Domain.Mappings
{
    public class SaleItemMappings : Profile
    {
        public SaleItemMappings()
        {
            CreateMap<SaleItemDTos, SaleItem>();
            CreateMap<SaleItem, SaleItemDTos>();
            CreateMap<SaleItemForCreateDTOs, SaleItem>();
            CreateMap<SaleItemForUpdateDTOs, SaleItem>();
        }
    }
}
