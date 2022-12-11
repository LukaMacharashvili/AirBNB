using FluentValidation;

namespace AirBNB.Application.Rooms.Queries.LoadRooms;

public class LoadRoomsCommandValidator : AbstractValidator<LoadRoomsQuery>
{
    public LoadRoomsCommandValidator()
    {
        RuleFor(x => x).NotEmpty();
    }
}