using Assignment2C2P.BusinessLogic.Implementation.Transactions;
using Assignment2C2P.BusinessLogic.Transactions;
using Assignment2C2P.DataAccess;
using Assignment2C2P.DataAccess.Implementation;
using Assignment2C2P.Repository.Implementation.Transactions;
using Assignment2C2P.Repository.Transactions;
using Assignment2C2P.Services.Implementation.Transactions;
using Assignment2C2P.Services.Transactions;
using Assignment2C2P.Utils.Logger;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment2C2P.IoC
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

            services.AddScoped<ILogger, Logger>();

            #region Repository
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            #endregion

            #region Business Logic
            services.AddScoped<ITransactionBusinessLogic, TransactionBusinessLogic>();
            #endregion

            #region Services
            services.AddScoped<ITransactionImporterServices, TransactionImporterServices>();
            services.AddScoped<ITransactionServices, TransactionServices>();
            #endregion

            return services;
        }
    }
}
