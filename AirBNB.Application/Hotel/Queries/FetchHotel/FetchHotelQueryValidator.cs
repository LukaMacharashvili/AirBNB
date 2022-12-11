using FluentValidation;

namespace AirBNB.Application.Hotels.Queries.FetchHotel;

public class FetchHotelQueryValidator : AbstractValidator<FetchHotelQuery>
{
    public FetchHotelQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}