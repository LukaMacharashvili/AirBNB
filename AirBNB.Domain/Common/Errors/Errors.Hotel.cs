using ErrorOr;

namespace AirBNB.Domain.Common.Errors;

public static partial class Errors
{
    public static class Hotel
    {
        public static Error HotelNotFound => Error.NotFound(
            code: "Hotel.HotelNotFound",
            description: "Hotel Not Found");
    }
}