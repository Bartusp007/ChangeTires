using Hedin.ChangeTires.Api.Controllers.Bookings.Responses;
using Hedin.ChangeTires.Api.Controllers.Common;
using Hedin.ChangeTires.Infrastructure.QueryServices.Prices;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hedin.ChangeTires.Api.Controllers.Prices
{
    [Route("api/price")]
    public class PriceController : BaseController
    {
        public PriceController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("carType/{carType:string}/tireSize/{tireSize:int}"), Produces(typeof(CalculatePriceResponse))]
        public async Task<IActionResult> CalculatePrice([FromRoute]string carType, [FromRoute] int tireSize, [FromQuery] bool includeWheelAlignment)
        {
            var result = await Handle(GetCalculatedPriceQuery.Create(carType, tireSize, includeWheelAlignment));
           
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(CalculatePriceResponse.MapFrom(result));
        }
    }
}
