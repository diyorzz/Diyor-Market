using DiyorMarket.Domain.Enterfaces.Repositories;
using DiyorMarket.Domain.Entities;

namespace DiyorMarket.Infrastructure.Persistence.Repositories
{
    public class SaleRepository : RepositoryBase<Sale>,ISaleRepository
    {
        public SaleRepository(DiyorMarketDbContext context) : base(context) { }
    }
}
