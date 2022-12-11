namespace AirBNB.Contracts.Rooms;

public record RoomResponse(
    Guid Id,
    string Name,
    string ImageUrl,
    string UserId);