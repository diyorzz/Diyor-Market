using DiyorMarket.Domain.Enterfaces.Repositories;
using DiyorMarket.Domain.Entities;

namespace DiyorMarket.Infrastructure.Persistence.Repositories
{
    public class SupplyItemRepository : RepositoryBase<SupplyItem> ,ISupplyItemRepository
    {
        public SupplyItemRepository(DiyorMarketDbContext dbContext) : base(dbContext) { }
    }
}
