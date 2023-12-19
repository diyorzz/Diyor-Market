using AutoMapper;
using DiyorMarket.Domain.DTOs.Supply;
using DiyorMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyorMarket.Domain.Mappings
{
    public class SupplyMappings : Profile
    {
        public SupplyMappings()
        {
            CreateMap<SupplyDTOs, Supply>();
            CreateMap<Supply, SupplyDTOs>();
            CreateMap<SupplyForCreateDTOs, Supply>();
            CreateMap<SupplyForUpdateDTOs, Supply>();
        }
    }
}
