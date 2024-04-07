using Microsoft.Extensions.DependencyInjection;
using Hedin.ChangeTires.Infrastructure.QueryServices.Slots;

namespace Hedin.ChangeTires.Infrastructure.QueryServices
{
    public static class QueryServicesRegistry
    {
        public static IServiceCollection AddQueryServices(this IServiceCollection services)
        {

            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(GetAvailableSlotsQuery).Assembly));

            return services;
        }
    }
}
