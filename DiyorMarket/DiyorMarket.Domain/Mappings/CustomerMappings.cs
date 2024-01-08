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
                .ForMember(x => x.FullName, r => r.MapFrom(x => x.FirstName + "" + x.LastName));
            CreateMap<Customer, Customer>();
            CreateMap<CustomerForCereateDTOs, Customer>();
            CreateMap<Customer,CustomerForCereateDTOs>();
            CreateMap<CustomerForUpdateDTOs, Customer>();
        }

    }
}
