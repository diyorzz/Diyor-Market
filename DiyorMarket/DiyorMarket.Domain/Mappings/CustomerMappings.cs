using AutoMapper;
using DiyorMarket.Domain.DTOs.Customer;
using DiyorMarket.Domain.Entities;

namespace DiyorMarket.Domain.Mappings
{
    public class CustomerMappings : Profile
    {
        public CustomerMappings()
        {
            CreateMap<Customer, CustomerDTOs>();
            CreateMap<Customer, Customer>();
            CreateMap<CustomerForCereateDTOs, Customer>();
            CreateMap<Customer,CustomerForCereateDTOs>();
            CreateMap<CustomerForUpdateDTOs, Customer>();
        }

    }
}
