using DiyorMarket.Domain.DTOs.Customer;
using DiyorMarket.Domain.Pagination;
using DiyorMarket.Domain.ResourceParameters;

namespace DiyorMarket.Domain.Enterfaces.Services
{
    public interface  ICustomerService
    {
        PaginatedList<CustomerDTO> GetCustomers(CustomerResourceParameters parameters);
        CustomerDTO? GetCustomerById(int id);
        CustomerDTO CreateCustomer(CustomerForCereateDTO customerForCereate);
        void UpdateCustomer(CustomerForUpdateDTO customerForUpdate);
        void DeleteCustomer(int id);
    }
}
