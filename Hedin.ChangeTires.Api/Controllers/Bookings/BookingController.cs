using Hedin.ChangeTires.Api.Controllers.Bookings.Requests;
using Hedin.ChangeTires.Api.Controllers.Bookings.Responses;
using Hedin.ChangeTires.Api.Controllers.Common;
using Hedin.ChangeTires.Infrastructure.CommandServices;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hedin.ChangeTires.Api.Controllers.Bookings
{
    [Route("api/booking")]
    public class BookingController : BaseController
    {
        public BookingController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost, Produces(typeof(CreateBookingResponse))]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingRequest createBookingRequest)
        {
            var result = await Handle(CreateBokingCommand.Create(createBookingRequest.ToCreateBokingDto()));

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok();
        }
    }
}
