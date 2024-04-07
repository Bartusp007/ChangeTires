using Microsoft.Extensions.DependencyInjection;

namespace Hedin.ChangeTires.Infrastructure.CommandServices
{
    public static class CommandServicesRegistry
    {
        public static IServiceCollection AddQueryServices(this IServiceCollection services)
        {

            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(CommandServicesRegistry).Assembly));

            return services;
        }
    }
}
