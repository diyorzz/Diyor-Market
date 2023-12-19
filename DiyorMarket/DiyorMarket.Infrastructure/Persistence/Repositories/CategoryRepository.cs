using DiyorMarket.Domain.Enterfaces.Repositories;
using DiyorMarket.Domain.Entities;

namespace DiyorMarket.Infrastructure.Persistence.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(DiyorMarketDbContext context) : base(context)
        {
            
        }
    }

}
