using DiscountManagement.Application;
using DiscountManagement.Application.Contract.CustomerDiscount;
using Microsoft.Extensions.DependencyInjection;
using DiscountManagement.Infrastructure.EFCore.Repository;
using DiscountManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace DiscountManagement.Configuration
{
    public class DiscountManagementBootstrapper
    {
        public static void Configure(IServiceCollection services , string connectionString)
        {
            services.AddTransient<ICustomerDiscountApplication,CustomerDiscountApplication>();
            services.AddTransient<ICustomerDiscountRepository,CustomerRepository>();


            services.AddDbContext<DiscountContext>(c => c.UseSqlServer(connectionString));
        }
    }
}
