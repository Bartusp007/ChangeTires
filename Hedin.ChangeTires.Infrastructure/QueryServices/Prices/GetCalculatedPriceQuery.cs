using Hedin.ChangeTires.Infrastructure.Services.Price;
using Hedin.ChangeTires.Infrastructure.Validators;
using MediatR;

namespace Hedin.ChangeTires.Infrastructure.QueryServices.Prices
{
    public sealed class GetCalculatedPriceQuery : IRequest<CalculatedPriceResultDto>
    {
        public string CarType { get; }
        public int TireSize { get; }
        public bool IncludeWheelAlignment { get; }
        private GetCalculatedPriceQuery(string carType, int tireSize, bool includeWheelAlignment)
        {
            CarType = carType;
            TireSize = tireSize;
            IncludeWheelAlignment = includeWheelAlignment;
        }

        public static GetCalculatedPriceQuery Create(string carType, int tireSize, bool includeWheelAlignment)
            => new GetCalculatedPriceQuery(carType, tireSize, includeWheelAlignment);


        public class GetCalculatedPriceQueryHandler : IRequestHandler<GetCalculatedPriceQuery, CalculatedPriceResultDto>
        {

            private readonly ICarTypeValidator _carTypeValidator;
            private readonly IChangeTirePriceCalculator _changeTirePriceCalculator;

            public GetCalculatedPriceQueryHandler(ICarTypeValidator carTypeValidator, IChangeTirePriceCalculator changeTirePriceCalculator)
            {
                _carTypeValidator = carTypeValidator;
                _changeTirePriceCalculator = changeTirePriceCalculator;
            }

            public async Task<CalculatedPriceResultDto> Handle(GetCalculatedPriceQuery request, CancellationToken cancellationToken)
            {
                if (!_carTypeValidator.VerifyCarTypeCorrectness(request.CarType))
                    return new CalculatedPriceResultDto { IsSuccess = false, ErrorMessage = $" Car type {request?.CarType ?? ""} is not valida" };


                var changeTiresPrice = _changeTirePriceCalculator.CalculateChangeTireAmount(
                                            ChangeTiresComponentsModel.Create(request.CarType, request.TireSize, request.IncludeWheelAlignment));

                if(changeTiresPrice == 0)
                    return new CalculatedPriceResultDto { IsSuccess = false, ErrorMessage = $" Unable calculate price." };

                return new CalculatedPriceResultDto { IsSuccess = true , Result = new CalculatedPriceDto() { Amount = changeTiresPrice }  };
            }
        }
    }

    public class CalculatedPriceResultDto
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public CalculatedPriceDto Result { get; set; }
    }

    public class CalculatedPriceDto
    {
        public decimal Amount { get; set; }
    }
}
