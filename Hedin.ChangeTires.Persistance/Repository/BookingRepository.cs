using Hedin.ChangeTires.Domain.BookingAggregate;
using Hedin.ChangeTires.Domain.BookingAggregate.Repository;

namespace Hedin.ChangeTires.Persistance.Repository
{
    public class BookingRepository : IBookingRepository
    {
        public async Task CreateBooking(Booking model)
        {
           //Implement persistance  repository service
        }
    }
}
