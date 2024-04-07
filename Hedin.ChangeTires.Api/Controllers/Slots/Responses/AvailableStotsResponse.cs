using Hedin.ChangeTires.Infrastructure.QueryServices.Slots;

namespace Hedin.ChangeTires.Api.Controllers.Bookings.Responses
{
    public class AvailableStotsResponse
    {
        public List<DateTime> SlotsTime { get; init; }

        public static AvailableStotsResponse MapFrom(AvailableSlotsDto availableSlot)
        {
            return new AvailableStotsResponse { SlotsTime = availableSlot.SlotsTime ?? new List<DateTime>() };
        }
    }
}
