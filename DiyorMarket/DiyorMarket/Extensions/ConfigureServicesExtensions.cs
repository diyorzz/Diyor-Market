using DiyorMarket.Domain.Enterfaces.Repositories;
using DiyorMarket.Domain.Enterfaces.Services;
using DiyorMarket.Infrastructure.Persistence;
using DiyorMarket.Infrastructure.Persistence.Repositories;
using DiyorMarket.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DiyorMarket.Extensions
{
    public static class ConfigureServicesExtensions
    {
        public static IServiceCollection ConfigureRipositories(this IServiceCollection services)
        {
            services.AddScoped<ICommonRepository, CommonRepository>();

            return services;
        }
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoriesService>();
            services.AddScoped<ICustomerService, CustomersService>();
            services.AddScoped<IProductService, ProductsService>();
            services.AddScoped<ISaleService, SalesService>();
            services.AddScoped<ISaleItemService, SaleItemsService>();
            services.AddScoped<ISupplierService, SuppliersService>();
            services.AddScoped<ISupplyService, SuppliesService>();
            services.AddScoped<ISuppyItemService, SupplyItemsService>();

            return services;
        }
        public static IServiceCollection ConfigureLogger(this IServiceCollection services)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File("logs/logs.txt", rollingInterval: RollingInterval.Day)
                .WriteTo.File("logs/error_.txt", Serilog.Events.LogEventLevel.Error, rollingInterval: RollingInterval.Day)
                .CreateLogger();

            return services;
        }
        public static IServiceCollection ConfigureDatabaseContext(this IServiceCollection services)
        {
            services.AddDbContext<DiyorMarketDbContext>(options =>
                options.UseSqlServer("Data Source=DESKTOP-7DUGPCC;Initial Catalog=DiyorMarket;Integrated Security=True;Trust Server Certificate=True"));

            return services;
        }
    }
}
