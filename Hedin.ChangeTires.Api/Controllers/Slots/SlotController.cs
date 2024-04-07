using Hedin.ChangeTires.Api.Controllers.Bookings.Responses;
using Hedin.ChangeTires.Api.Controllers.Common;
using Hedin.ChangeTires.Infrastructure.QueryServices.Slots;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hedin.ChangeTires.Api.Controllers.Slots
{
    [Route("api/slot")]
    public class SlotController : BaseController
    {
        public SlotController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet, Produces(typeof(AvailableStotsResponse))]
        public async Task<IActionResult> GetAvailableSlots()
        {
            var result = await Handle(GetAvailableSlotsQuery.Create());

            return Ok(AvailableStotsResponse.MapFrom(result));
        }
    }
}
