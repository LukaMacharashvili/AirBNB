using AirBNB.Application.BookDates.Common;
using ErrorOr;
using MediatR;

namespace AirBNB.Application.BookDates.Commands.UnbookRoom;

public record UnbookRoomCommand(string Id) : IRequest<ErrorOr<BookDateResult>>;