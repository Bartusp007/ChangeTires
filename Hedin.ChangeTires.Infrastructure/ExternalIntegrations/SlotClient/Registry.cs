using Hedin.ChangeTires.Infrastructure.ExternalIntegrations.SlotClient.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Hedin.ChangeTires.Infrastructure.ExternalIntegrations.SlotClient
{
    public static class Registry
    {
        public static IServiceCollection AddExternalSlotApiClient<TSettingsType>(this IServiceCollection services) where TSettingsType : class, IExternalServiceConfiguration, new()
        {
            services.AddSingleton((Func<IServiceProvider, IExternalServiceConfiguration>)((IServiceProvider container) => container.GetService<IOptions<TSettingsType>>()!.Value));

            services.AddHttpClient<ExternalSlotApiClient>((serviceProvider, client) =>
            {
                var settings = serviceProvider.GetRequiredService<IExternalServiceConfiguration>();
                client.BaseAddress = new Uri(settings.ExternalServiceConfiguration.Url);
            });

            services.AddScoped<IExternalSlotApiClient, ExternalSlotApiClient>();

            return services;
        }

    }
}
