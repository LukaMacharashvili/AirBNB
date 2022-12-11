namespace AirBNB.Contracts.Rooms;

public record CreateRoomRequest(
    string Name,
    string ImageUrl);