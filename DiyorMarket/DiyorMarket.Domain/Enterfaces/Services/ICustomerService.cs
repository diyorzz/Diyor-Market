using DiyorMarket.Domain.DTOs.Customer;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;

namespace DiyorMarket.Domain.Enterfaces.Services
{
    public interface  ICustomerService
    {
        PaginatedList<CustomerDtOs> GetCustomers(CustomerResourceParameters parameters);
        CustomerDtOs? GetCustomerById(int id);
        CustomerDtOs CreateCustomer(CustomerForCereateDTOs customerForCereate);
        void UpdateCustomer(CustomerForUpdateDTOs customerForUpdate);
        void DeleteCustomer(int id);
    }
}
