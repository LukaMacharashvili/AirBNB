namespace AirBNB.Contracts.BookDates;

public record BookDateResponse(
    DateOnly StartDate,
    DateOnly EndDate,
    string RoomId);