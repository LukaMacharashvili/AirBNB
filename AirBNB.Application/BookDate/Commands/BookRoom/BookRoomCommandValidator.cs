using AirBNB.Application.BookDates.Commands.BookRoom;
using FluentValidation;

namespace AirBNB.Application.BookDates.Commands.BookRooms;

public class BookRoomsCommandValidator : AbstractValidator<BookRoomCommand>
{
    public BookRoomsCommandValidator()
    {
        RuleFor(x => x.StartDate).NotEmpty();
        RuleFor(x => x.EndDate).NotEmpty();
        RuleFor(x => x.RoomId).NotEmpty();
    }
}