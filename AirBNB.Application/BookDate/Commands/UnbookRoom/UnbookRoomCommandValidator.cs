using FluentValidation;

namespace AirBNB.Application.BookDates.Commands.UnbookRoom;

public class UnbookRoomCommandValidator : AbstractValidator<UnbookRoomCommand>
{
    public UnbookRoomCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}