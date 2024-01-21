using AutoMapper;
using DiyorMarket.Domain.DTOs.Customer;
using DiyorMarket.Domain.Entities;

namespace DiyorMarket.Domain.Mappings
{
    public class CustomerMappings : Profile
    {
        public CustomerMappings()
        {
            CreateMap<Customer, CustomerDTOs>()
                    .ForCtorParam("FullName", opt => opt.MapFrom(src => string.Join(" ", src.FirstName, src.LastName)));
            CreateMap<Customer, Customer>();
            CreateMap<CustomerForCereateDTOs, Customer>();
            CreateMap<Customer, CustomerForCereateDTOs>();
            CreateMap<CustomerForUpdateDTOs, Customer>();
        }
    }
}
