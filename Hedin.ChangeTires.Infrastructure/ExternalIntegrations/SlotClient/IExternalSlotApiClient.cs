using Hedin.ChangeTires.Infrastructure.ExternalIntegrations.SlotClient.Models;

namespace Hedin.ChangeTires.Infrastructure.ExternalIntegrations.SlotClient
{
    public interface IExternalSlotApiClient
    {
        Task<AvailableSlotsResponseDto> GetAvailableSlotsAsync();
        Task<BookingResponseDto> BookAsync(DateTime slot);
    }
}
