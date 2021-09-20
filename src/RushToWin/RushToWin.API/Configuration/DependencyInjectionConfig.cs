using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RushToWin.API.Data.Context;
using RushToWin.API.Data.Repositories;
using RushToWin.API.Domain.Interfaces.Repositories;
using RushToWin.API.Domain.Interfaces.Services;
using RushToWin.API.Domain.Services;

namespace RushToWin.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MyDbContext>();

            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IWalletRepository, WalletRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IWalletService, WalletService>();
            services.AddScoped<IUserService, UserService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            return services;
        }
    }
}
