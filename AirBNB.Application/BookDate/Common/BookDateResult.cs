using AirBNB.Domain.BookDates;

namespace AirBNB.Application.BookDates.Common;

public record BookDateResult(
    DateOnly StartDate,
    DateOnly EndDate,
    string RoomId);