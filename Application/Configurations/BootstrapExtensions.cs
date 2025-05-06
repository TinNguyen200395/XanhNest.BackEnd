using System;
using XanhNest.BackEndServer.Application.Interfaces;
using XanhNest.BackEndServer.Application.Services;
using XanhNest.BackEndServer.Persistence.Repositories.Implements;
using XanhNest.BackEndServer.Persistence.Repositories.Interfaces;

namespace XanhNest.BackEndServer.Application.Configurations
{
    public static class BootstrapExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAuthRepository, AuthRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}

