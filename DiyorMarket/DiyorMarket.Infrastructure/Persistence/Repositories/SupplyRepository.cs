using DiyorMarket.Domain.Enterfaces.Repositories;
using DiyorMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyorMarket.Infrastructure.Persistence.Repositories
{
    public class SupplyRepository : RepositoryBase<Supply> ,ISupplyRepository
    {
        public SupplyRepository(DiyorMarketDbContext context) : base(context) { }
    }
}
