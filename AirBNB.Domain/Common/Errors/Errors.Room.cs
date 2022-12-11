using ErrorOr;

namespace AirBNB.Domain.Common.Errors;

public static partial class Errors
{
    public static class Room
    {
        public static Error RoomNotFound => Error.NotFound(
            code: "Room.RoomNotFound",
            description: "Room Not Found");
    }
}