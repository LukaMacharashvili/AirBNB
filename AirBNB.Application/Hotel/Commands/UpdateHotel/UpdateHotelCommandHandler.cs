using AirBNB.Application.Hotels.Common;
using AirBNB.Application.Common.Interfaces.Persistence;
using AirBNB.Domain.Common.Errors;
using AirBNB.Domain.Hotels;
using ErrorOr;
using MediatR;

namespace AirBNB.Application.Hotels.Commands.UpdateHotel;

public class UpdateHotelCommandHandler :
    IRequestHandler<UpdateHotelCommand, ErrorOr<HotelResult>>
{
    private readonly IHotelRepository _hotelRepository;

    public UpdateHotelCommandHandler(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    public async Task<ErrorOr<HotelResult>> Handle(UpdateHotelCommand command, CancellationToken cancellationToken)
    {
        var hotel = _hotelRepository.Fetch(command.Id);
        if (hotel is null) return Errors.Hotel.HotelNotFound;

        hotel.Name = command.Name;
        hotel.ImageUrl = command.ImageUrl;
        _hotelRepository.Save();

        return new HotelResult((Hotel)hotel);
    }
}