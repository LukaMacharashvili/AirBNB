namespace AirBNB.Contracts.BookDates;

public record BookRoomRequest(
    DateTime StartDate,
    DateTime EndDate,
    string RoomId);