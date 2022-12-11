using AirBNB.Application.BookDates.Queries.LoadBookDates;
using FluentValidation;

namespace AirBNB.Application.BookDates.Query.LoadBookDates;

public class LoadBookDatesCommandValidators : AbstractValidator<LoadBookDatesQuery>
{
    public LoadBookDatesCommandValidators()
    {
        RuleFor(x => x.RoomId).NotEmpty();
    }
}