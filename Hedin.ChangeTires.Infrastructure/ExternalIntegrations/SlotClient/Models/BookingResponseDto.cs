namespace Hedin.ChangeTires.Infrastructure.ExternalIntegrations.SlotClient.Models
{
    public class BookingResponseDto
    {
        private BookingResponseDto( bool isSuccess, string? errorMessage)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;

        }

        public bool IsSuccess { get; private set; }
        public string? ErrorMessage { get; private set; }

        public static BookingResponseDto Ok() => new BookingResponseDto(true, null);

        public static BookingResponseDto Fail( string errorMessage) => new BookingResponseDto(true, errorMessage);
    }
}
