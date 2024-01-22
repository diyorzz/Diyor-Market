using AutoMapper;
using DiyorMarket.Domain.DTOs.Customer;
using DiyorMarket.Domain.Entities;

namespace DiyorMarket.Domain.Mappings
{
    public class CustomerMappings : Profile
    {
        public CustomerMappings()
        {
            CreateMap<Customer, CustomerDTO>()
                    .ForCtorParam("FullName", opt => opt.MapFrom(src => string.Join(" ", src.FirstName, src.LastName)));
            CreateMap<Customer, Customer>();
            CreateMap<CustomerForCereateDTO, Customer>();
            CreateMap<Customer, CustomerForCereateDTO>();
            CreateMap<CustomerForUpdateDTO, Customer>();
        }
    }
}
