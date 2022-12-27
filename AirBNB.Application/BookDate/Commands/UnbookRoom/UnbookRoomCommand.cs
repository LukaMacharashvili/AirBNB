using AirBNB.Application.BookDates.Common;
using ErrorOr;
using MediatR;

namespace AirBNB.Application.BookDates.Commands.UnbookRoom;

public record UnbookRoomCommand(
    DateOnly StartDate,
    DateOnly EndDate,
    string RoomId) : IRequest<ErrorOr<BookDateResult>>;