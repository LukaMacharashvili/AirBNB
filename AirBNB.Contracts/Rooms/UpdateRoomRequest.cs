namespace AirBNB.Contracts.Rooms;

public record UpdateRoomRequest(
    string Name,
    string ImageUrl);