using Hedin.ChangeTires.Infrastructure.CommandServices;
using Hedin.ChangeTires.Infrastructure.Services;
using Hedin.ChangeTires.Infrastructure.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace Hedin.ChangeTires.Infrastructure
{
    public static class InfrastructureRegistry
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddValidators();
            services.AddPriceService();
            services.AddQueryServices();
            services.AddQueryServices();

            return services;
        }
    }
}
