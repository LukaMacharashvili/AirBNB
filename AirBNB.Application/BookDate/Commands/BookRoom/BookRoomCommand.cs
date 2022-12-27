using AirBNB.Application.BookDates.Common;
using ErrorOr;
using MediatR;

namespace AirBNB.Application.BookDates.Commands.BookRoom;

public record BookRoomCommand(
    DateOnly StartDate,
    DateOnly EndDate,
    string RoomId) : IRequest<ErrorOr<BookDateResult>>;