namespace AirBNB.Contracts.BookDates;

public record BookDateResponse(
    Guid Id,
    DateTime StartDate,
    DateTime EndDate,
    string RoomId);