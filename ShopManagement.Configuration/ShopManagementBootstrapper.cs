using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.Category;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Infrastructure.EFCore;
using ShopManagement.Infrastructure.EFCore.Repository;

namespace ShopManagement.Configuration
{
    public class ShopManagementBootstrapper
    {
        public static void Configure(IServiceCollection services , string connectionString)
        {
            services.AddTransient<ICategoryApplication, CategoryApplication>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductApplication, ProductApplication>();
            services.AddTransient<IProductRepository, ProductRepository>();


            services.AddDbContext<ShopContext>(c=>c.UseSqlServer(connectionString));

        }
    }
}