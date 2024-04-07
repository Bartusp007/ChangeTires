namespace Hedin.ChangeTires.Domain.BookingAggregate
{
    public class Booking
    {
        public long Id { get; private set; }

        public DateTime SlotTime { get; private set; }
        public decimal Price { get; private set; }

        public string CarType { get; private set; }
        public int TireSize { get; private set; }
        public bool IncludeWheelAlignment { get; private set; }

        public Customer Customer { get; set; }


        private Booking(DateTime slotTime, decimal price, string carType, int tireSize, bool includeWheelAlignment, Customer customer)
        {
            SlotTime = slotTime;
            Price = price;
            CarType = carType;
            TireSize = tireSize;
            IncludeWheelAlignment = includeWheelAlignment;
            Customer = customer;
        }

        public static Booking CreateBooking(DateTime slotTime, decimal price, string carType, int tireSize, bool includeWheelAlignment, Customer customer)
        {
            //1.)Add validation to make domain consisten. As a result of Create method should be returned Result Model with vaklidation instead thrown exception

            //2). Publish Domain Event that booking has been created

            //3) Ther shoulld be handler which will be send email confirmation to customer.

            return new Booking(slotTime, price, carType, tireSize, includeWheelAlignment, customer);
        }

    }
}