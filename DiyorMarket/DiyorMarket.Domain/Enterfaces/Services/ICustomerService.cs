using DiyorMarket.Domain.DTOs.Customer;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;

namespace DiyorMarket.Domain.Enterfaces.Services
{
    public interface  ICustomerService
    {
        PaginatedList<CustomerDTOs> GetCustomers(CustomerResourceParameters parameters);
        CustomerDTOs? GetCustomerById(int id);
        CustomerDTOs CreateCustomer(CustomerForCereateDTOs customerForCereate);
        void UpdateCustomer(CustomerForUpdateDTOs customerForUpdate);
        void DeleteCustomer(int id);
    }
}
