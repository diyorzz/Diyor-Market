using DiyorMarket.Domain.Enterfaces.Repositories;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiyorMarket.Infrastructure.Persistence.Repositories
{
    public class SaleRepository : RepositoryBase<Sale>,ISaleRepository
    {
        public SaleRepository(DiyorMarketDbContext context) : base(context) { }
    }
}
