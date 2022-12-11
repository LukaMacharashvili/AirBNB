using FluentValidation;

namespace AirBNB.Application.Rooms.Commands.DeleteRoom;

public class DeleteRoomCommandValidator : AbstractValidator<DeleteRoomCommand>
{
    public DeleteRoomCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}