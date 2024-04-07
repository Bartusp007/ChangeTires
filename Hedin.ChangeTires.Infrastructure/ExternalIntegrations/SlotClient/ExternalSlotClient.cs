using System.Net.Http.Json;
using Hedin.ChangeTires.Infrastructure.ExternalIntegrations.SlotClient.Models;
using Hedin.ChangeTires.Infrastructure.ExternalIntegrations.SlotClient.Settings;

namespace Hedin.ChangeTires.Infrastructure.ExternalIntegrations.SlotClient
{
    public sealed class ExternalSlotApiClient: IExternalSlotApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly IExternalServiceConfiguration _settings;

        public ExternalSlotApiClient(HttpClient httpClient, IExternalServiceConfiguration settings)
        {
            _httpClient = httpClient;
            _settings = settings;
        }
        public async Task<AvailableSlotsResponseDto> GetAvailableSlotsAsync()
        {
            var response = await _httpClient.GetAsync(_settings.ExternalServiceConfiguration.Url + "/slots");
            response.EnsureSuccessStatusCode();

            var slots = response.Content.ReadFromJsonAsync<List<DateTime>>().Result;
            return new AvailableSlotsResponseDto() { AvailableSlots = slots ?? new List<DateTime>() } ;
        }

        public async Task<BookingResponseDto> BookAsync(DateTime slot)
        {
                var response = await _httpClient.PostAsJsonAsync(_settings.ExternalServiceConfiguration.Url + "/slots", slot);
                return response.IsSuccessStatusCode ? BookingResponseDto.Ok() : BookingResponseDto.Fail($"Unable book slot :{slot}.");
        }
    }
}
