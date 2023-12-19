using DiyorMarket.Domain.Enterfaces.Repositories;
using DiyorMarket.Domain.Entities;

namespace DiyorMarket.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(DiyorMarketDbContext context) : base(context) { }
    }
}
