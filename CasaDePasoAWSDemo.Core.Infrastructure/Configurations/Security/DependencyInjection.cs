using CasaDePasoAWSDemo.Core.Application.Interfaces.IRepositories;
using CasaDePasoAWSDemo.Core.Application.Interfaces.IServices;
using CasaDePasoAWSDemo.Core.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CasaDePasoAWSDemo.Core.Infrastructure.Configurations.Security
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IPasswordHasherService, PasswordHasherService>();
            return services;
        }
    }
}
