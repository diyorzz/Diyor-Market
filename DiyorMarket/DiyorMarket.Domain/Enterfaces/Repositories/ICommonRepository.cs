
namespace DiyorMarket.Domain.Enterfaces.Repositories
{
    public interface ICommonRepository
    {
        public IProductRepository Product { get; }
        public ICategoryRepository Category { get; }

        public int SaveChanges();
        public Task<int> SaveChangesAsync();
    }

}
