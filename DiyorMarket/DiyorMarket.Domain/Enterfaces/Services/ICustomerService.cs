using DiyorMarket.Domain.DTOs.Category;
using DiyorMarket.Domain.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
