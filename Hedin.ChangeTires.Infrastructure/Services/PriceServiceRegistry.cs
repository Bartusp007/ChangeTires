using Hedin.ChangeTires.Infrastructure.Services.Price;
using Hedin.ChangeTires.Infrastructure.Services.Price.PriceComponents;
using Microsoft.Extensions.DependencyInjection;

namespace Hedin.ChangeTires.Infrastructure.Services
{
    public static class PriceServiceRegistry
    {

        public static IServiceCollection AddPriceService(this IServiceCollection services)
        {
            services.AddScoped<BaseComponent, CarTypeComponent>();
            services.AddScoped<BaseComponent, IncludeWheelAlignmentComponent>();
            services.AddScoped<BaseComponent, TireSizeComponent>();

            services.AddScoped<IChangeTirePriceCalculator, ChangeTirePriceCalculator>();

            return services;
        }
    }
}
