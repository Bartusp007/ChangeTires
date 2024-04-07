using Hedin.ChangeTires.Infrastructure.ExternalIntegrations.SlotClient;
using Hedin.ChangeTires.Infrastructure.ExternalIntegrations.SlotClient.Models;
using MediatR;

namespace Hedin.ChangeTires.Infrastructure.QueryServices.Slots
{
    public sealed class GetAvailableSlotsQuery : IRequest<AvailableSlotsDto>
    {
        private GetAvailableSlotsQuery()
        {   
        }

        public static GetAvailableSlotsQuery Create() => new GetAvailableSlotsQuery();
    }

    public class GetAvailableSlotsQueryHandler : IRequestHandler<GetAvailableSlotsQuery, AvailableSlotsDto>
    {
        private readonly IExternalSlotApiClient _externalSlotApiClient;

        public GetAvailableSlotsQueryHandler(IExternalSlotApiClient externalSlotApiClient)
        {
            _externalSlotApiClient = externalSlotApiClient;
        }

        public async Task<AvailableSlotsDto> Handle(GetAvailableSlotsQuery request, CancellationToken cancellationToken)
        {
            var slots = await _externalSlotApiClient.GetAvailableSlotsAsync();

            return MapToAvailableSlotDto(slots);
        }

        private AvailableSlotsDto MapToAvailableSlotDto(AvailableSlotsResponseDto slots)
        {
            return new AvailableSlotsDto() { SlotsTime = slots.AvailableSlots };
        }
    }

    public class AvailableSlotsDto
    {
        public List<DateTime> SlotsTime { get; init; }
    }
}
