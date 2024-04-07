using Hedin.ChangeTires.Domain.BookingAggregate;
using Hedin.ChangeTires.Domain.BookingAggregate.Repository;
using Hedin.ChangeTires.Infrastructure.ExternalIntegrations.SlotClient;
using Hedin.ChangeTires.Infrastructure.QueryServices.Prices;
using Hedin.ChangeTires.Infrastructure.Services.Price;
using Hedin.ChangeTires.Infrastructure.Validators;
using MediatR;

namespace Hedin.ChangeTires.Infrastructure.CommandServices
{
    public class CreateBokingCommand : IRequest<CreateBokingResult>
    {
        private CreateBokingCommand(CreateBokingDto bookingRequest)
        {
            BookingRequest = bookingRequest;
        }

        public CreateBokingDto BookingRequest { get; }

        public static CreateBokingCommand Create(CreateBokingDto bookingRequest)
                => new CreateBokingCommand(bookingRequest);
    }

    public class CreateBokingCommandHandler : IRequestHandler<CreateBokingCommand, CreateBokingResult>
    {
        private readonly IExternalSlotApiClient _externalSlotApiClient;
        private readonly ICarTypeValidator _carTypeValidator;
        private readonly IChangeTirePriceCalculator _changeTirePriceCalculator;
        private readonly IBookingRepository _bookingRepository;

        public CreateBokingCommandHandler(IExternalSlotApiClient externalSlotApiClient, ICarTypeValidator carTypeValidator, IChangeTirePriceCalculator changeTirePriceCalculator, IBookingRepository bookingRepository)
        {
            _externalSlotApiClient = externalSlotApiClient;
            _carTypeValidator = carTypeValidator;
            _changeTirePriceCalculator = changeTirePriceCalculator;
            _bookingRepository = bookingRepository;
        }

        public async Task<CreateBokingResult> Handle(CreateBokingCommand request, CancellationToken cancellationToken)
        {
            var availableSlots = await _externalSlotApiClient.BookAsync(request.BookingRequest.SlotDate);

            if(!availableSlots.IsSuccess)
                return new CreateBokingResult() { IsSuccess = false, ErrorMessage = availableSlots.ErrorMessage };


            if (request.BookingRequest.CarDetails != null)
                return new CreateBokingResult { IsSuccess = false, ErrorMessage = $" Car details are required." };


            if (request.BookingRequest.Customer != null)
                return new CreateBokingResult { IsSuccess = false, ErrorMessage = $" Customer details are required." };

            if (!_carTypeValidator.VerifyCarTypeCorrectness(request?.BookingRequest?.CarDetails.CarType))
                return new CreateBokingResult { IsSuccess = false, ErrorMessage = $" Car type {request.BookingRequest.CarDetails.CarType ?? ""} is not valida" };


            var price = _changeTirePriceCalculator.CalculateChangeTireAmount(
                            ChangeTiresComponentsModel.Create(request.BookingRequest.CarDetails.CarType, 
                                                              request.BookingRequest.CarDetails.TireSize, 
                                                              request.BookingRequest.CarDetails.IncludeWheelAlignment));

            var customer = Domain.Customer.Create(request.BookingRequest.Customer.CustomerName,
                                                  request.BookingRequest.Customer.Email);

            var booking = Booking.CreateBooking(request.BookingRequest.SlotDate,
                                                       price,
                                                       request.BookingRequest.CarDetails.CarType,
                                                       request.BookingRequest.CarDetails.TireSize,
                                                       request.BookingRequest.CarDetails.IncludeWheelAlignment,
                                                       customer);

            await _bookingRepository.CreateBooking(booking);

            return new CreateBokingResult() { IsSuccess = true };
        }
    }

    public class CreateBokingResult
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class CreateBokingDto
    {
        public CustomerDetailsDto Customer { get; set; }
        public DateTime SlotDate { get; set; }

        public ChangeTiresCarDetailsDto CarDetails;
    }

    public class CustomerDetailsDto
    {
        public string CustomerName { get; set; }
        public string Email { get; set; }
    }

    public class ChangeTiresCarDetailsDto
    {
        public string CarType { get; set; }
        public int TireSize { get; set; }
        public bool IncludeWheelAlignment { get; set; }
    }
}
