using DiyorMarket.Domain.DTOs.Customer;

namespace DiyorMarket.Domain.Enterfaces.Services
{
    public interface  ICustomerService
    {
        IEnumerable<CustomerDtOs> GetCustomers();
        CustomerDtOs? GetCustomerById(int id);
        CustomerDtOs CreateCustomer(CustomerForCereateDTOs customerForCereate);
        void UpdateCustomer(CustomerForUpdateDTOs customerForUpdate);
        void DeleteCustomer(int id);
    }
}
