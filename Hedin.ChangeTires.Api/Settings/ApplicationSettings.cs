using Hedin.ChangeTires.Infrastructure.ExternalIntegrations.SlotClient.Settings;

namespace Hedin.ChangeTires.Api.Settings
{
    public class ApplicationSettings : IExternalServiceConfiguration
    {
        public ExternalServiceSettings ExternalServiceConfiguration { get; set; }
    }
}
