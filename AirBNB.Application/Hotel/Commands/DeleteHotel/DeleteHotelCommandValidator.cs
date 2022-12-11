using FluentValidation;

namespace AirBNB.Application.Hotels.Commands.DeleteHotel;

public class DeleteHotelCommandValidator : AbstractValidator<DeleteHotelCommand>
{
    public DeleteHotelCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}