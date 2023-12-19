using AutoMapper;
using DiyorMarket.Domain.DTOs.Supplier;
using DiyorMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyorMarket.Domain.Mappings
{
    public class SupplierMappings : Profile
    {
        public SupplierMappings()
        {
            CreateMap<SupplierDTOs, Supplier>();
            CreateMap<Supplier, SupplierDTOs>();
            CreateMap<SupplierForCreateDTOs, Supplier>();
            CreateMap<SupplierForUpdateDTOs, Supplier>();
        }
    }
}
