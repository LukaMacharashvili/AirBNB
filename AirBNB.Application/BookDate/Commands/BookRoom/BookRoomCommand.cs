using AirBNB.Application.BookDates.Common;
using ErrorOr;
using MediatR;

namespace AirBNB.Application.BookDates.Commands.BookRoom;

public record BookRoomCommand(
    DateTime StartDate,
    DateTime EndDate,
    string RoomId) : IRequest<ErrorOr<BookDateResult>>;