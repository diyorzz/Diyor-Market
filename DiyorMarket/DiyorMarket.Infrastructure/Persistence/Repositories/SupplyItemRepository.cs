using DiyorMarket.Domain.Enterfaces.Repositories;
using DiyorMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyorMarket.Infrastructure.Persistence.Repositories
{
    public class SupplyItemRepository : RepositoryBase<SupplyItem> ,ISupplyItemRepository
    {
        public SupplyItemRepository(DiyorMarketDbContext dbContext) : base(dbContext) { }
    }
}
