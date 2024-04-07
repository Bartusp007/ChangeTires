using Hedin.ChangeTires.Infrastructure.QueryServices.Prices;

namespace Hedin.ChangeTires.Api.Controllers.Bookings.Responses
{
    public class CalculatePriceResponse
    {
        public decimal Amount { get; set; }

        public static CalculatePriceResponse MapFrom(CalculatedPriceResultDto model)
        {
            if (!model.IsSuccess)
                return null;

            return new CalculatePriceResponse()
            {
                Amount = model.Result.Amount
            };
        }
    }
}
