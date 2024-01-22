using AutoMapper;
using DiyorMarket.Domain.DTOs.SaleItam;
using DiyorMarket.Domain.Entities;

namespace DiyorMarket.Domain.Mappings
{
    public class SaleItemMappings : Profile
    {
        public SaleItemMappings()
        {
            CreateMap<SaleItemDTO, SaleItem>();
            CreateMap<SaleItem, SaleItemDTO>();
            CreateMap<SaleItemForCreateDTO, SaleItem>();
            CreateMap<SaleItemForUpdateDTO, SaleItem>();
        }
    }
}
