using DiyorMarket.Domain.Enterfaces.Repositories;
using DiyorMarket.Domain.Entities;

namespace DiyorMarket.Infrastructure.Persistence.Repositories
{
    public class SupplierRepository : RepositoryBase<Supplier>,ISupplierRepository
    {
        public SupplierRepository(DiyorMarketDbContext context) : base(context) { }
    }
}
