using AirBNB.Application.Hotels.Common;
using AirBNB.Application.Common.Interfaces.Persistence;
using AirBNB.Domain.Hotels;
using ErrorOr;
using MediatR;

namespace AirBNB.Application.Hotels.Commands.CreateHotel;

public class CreateHotelCommandHandler :
    IRequestHandler<CreateHotelCommand, ErrorOr<HotelResult>>
{
    private readonly IHotelRepository _hotelRepository;

    public CreateHotelCommandHandler(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    public async Task<ErrorOr<HotelResult>> Handle(CreateHotelCommand command, CancellationToken cancellationToken)
    {
        var hotel = Hotel.Create(
            command.UserId,
            command.Name,
            command.ImageUrl);

        _hotelRepository.Add(hotel);
        _hotelRepository.Save();

        return new HotelResult(hotel);
    }
}