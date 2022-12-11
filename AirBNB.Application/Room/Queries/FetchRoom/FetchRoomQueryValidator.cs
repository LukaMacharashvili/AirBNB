using FluentValidation;

namespace AirBNB.Application.Rooms.Queries.FetchRoom;

public class FetchRoomQueryValidator : AbstractValidator<FetchRoomQuery>
{
    public FetchRoomQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}