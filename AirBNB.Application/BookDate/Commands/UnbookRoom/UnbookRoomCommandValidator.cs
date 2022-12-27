using FluentValidation;

namespace AirBNB.Application.BookDates.Commands.UnbookRoom;

public class UnbookRoomCommandValidator : AbstractValidator<UnbookRoomCommand>
{
    public UnbookRoomCommandValidator()
    {
        RuleFor(x => x.StartDate).NotEmpty();
        RuleFor(x => x.EndDate).NotEmpty();
        RuleFor(x => x.RoomId).NotEmpty();
    }
}