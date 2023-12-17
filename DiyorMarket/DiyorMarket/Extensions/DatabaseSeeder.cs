using Bogus;
using DiyorMarket.Domain.Entities;
using DiyorMarket.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DiyorMarket.Extensions
{
    public static class DatabaseSeeder
    {
        private static Faker _faker = new Faker();

        public static void SeedDatabase(this IServiceCollection _, IServiceProvider serviceProvider)
        {
            var options = serviceProvider.GetRequiredService<DbContextOptions<DiyorMarketDbContext>>();
            using var context = new DiyorMarketDbContext(options);

            CreateProducts(context);
        }

        public static void CreateProducts(DiyorMarketDbContext context)
        {
            if (context.Products.Any()) return;

            var categories = context.Categories.ToList();
            var productNames = new List<string>();
            var products = new List<Product>();

            foreach (var category in categories)
            {
                var productsCount = new Random().Next(5, 35);

                for (int i = 0; i < productsCount; i++)
                {
                    var productName = _faker.Commerce.ProductName().FirstLetterToUpper();
                    int attempts = 0;

                    while (productNames.Contains(productName) && attempts < 100)
                    {
                        productName = _faker.Commerce
                            .ProductName()
                            .FirstLetterToUpper();

                        attempts++;
                    }

                    productNames.Add(productName);

                    products.Add(new Product
                    {
                        Name = productName,
                        Description = _faker.Commerce.ProductDescription(),
                        Price = _faker.Random.Decimal(10_000, 2_000_000),
                        CategoryId = category.Id,
                    });
                }
            }
        }
    }
}
