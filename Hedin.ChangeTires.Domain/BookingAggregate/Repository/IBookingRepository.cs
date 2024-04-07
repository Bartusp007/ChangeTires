namespace Hedin.ChangeTires.Domain.BookingAggregate.Repository
{
    public interface IBookingRepository
    {
        Task CreateBooking(Booking model);
    }
}
