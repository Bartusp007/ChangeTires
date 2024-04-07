using Hedin.ChangeTires.Infrastructure.CommandServices;

namespace Hedin.ChangeTires.Api.Controllers.Bookings.Requests
{
    public class CreateBookingRequest
    {
        public CustomerDetails Customer { get; set; }
        public DateTime SlotDate { get; set; }

        public ChangeTiresCarDetails CarDetails;

        public CreateBokingDto ToCreateBokingDto()
        {
            return new CreateBokingDto
            {
                Customer = Customer.ToCustomerDetailsDto(),
                SlotDate = SlotDate,
                CarDetails = CarDetails.ToChangeTiresCarDetailsDto(),
            };
        }
    }

    public class CustomerDetails
     {
        public string CustomerName { get; set; }
        public string Email { get; set; }

        public CustomerDetailsDto ToCustomerDetailsDto()
        {
            return new CustomerDetailsDto
            {
                CustomerName = CustomerName,
                Email = Email,
            };
        }
    }

    public class ChangeTiresCarDetails
    {
        public string CarType { get; set; }
        public int TireSize { get; set; }
        public bool IncludeWheelAlignment { get; set; }

        public ChangeTiresCarDetailsDto ToChangeTiresCarDetailsDto()
        {
            return new ChangeTiresCarDetailsDto()
            {
                CarType = CarType,
                IncludeWheelAlignment = IncludeWheelAlignment,
                TireSize = TireSize
            };
        }
    }
}
