using FluentValidation;

namespace AirBNB.Application.Hotels.Commands.CreateHotel;

public class CreateHotelCommandValidator : AbstractValidator<CreateHotelCommand>
{
    public CreateHotelCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.ImageUrl).NotEmpty();
        RuleFor(x => x.UserId).NotEmpty();
    }
}