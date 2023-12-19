using DiyorMarket.Domain.Enterfaces.Repositories;
using DiyorMarket.Domain.Entities;

namespace DiyorMarket.Infrastructure.Persistence.Repositories
{
    public class SupplyRepository : RepositoryBase<Supply> ,ISupplyRepository
    {
        public SupplyRepository(DiyorMarketDbContext context) : base(context) { }
    }
}
