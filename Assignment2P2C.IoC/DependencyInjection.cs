using Assignment2P2C.BusinessLogic.Implementation.Transactions;
using Assignment2P2C.BusinessLogic.Transactions;
using Assignment2P2C.DataAccess;
using Assignment2P2C.DataAccess.Implementation;
using Assignment2P2C.Repository.Implementation.Transactions;
using Assignment2P2C.Repository.Transactions;
using Assignment2P2C.Services.Implementation.Transactions;
using Assignment2P2C.Services.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment2P2C.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddIoC(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("TransactionDatabase");
            #region Persistence

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            #endregion

            #region Repository
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            #endregion

            services.AddScoped<ITransactionBusinessLogic, TransactionBusinessLogic>();
            services.AddScoped<ITransactionServices, TransactionServices>();

            return services;
        }
    }
}
