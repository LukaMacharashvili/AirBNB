using AirBNB.Application.Hotels.Common;
using AirBNB.Application.Common.Interfaces.Persistence;
using AirBNB.Domain.Common.Errors;
using AirBNB.Domain.Hotels;
using ErrorOr;
using MediatR;

namespace AirBNB.Application.Hotels.Commands.DeleteHotel;
public class DeleteHotelCommandHandler :
    IRequestHandler<DeleteHotelCommand, ErrorOr<HotelResult>>
{
    private readonly IHotelRepository _hotelRepository;

    public DeleteHotelCommandHandler(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    public async Task<ErrorOr<HotelResult>> Handle(DeleteHotelCommand command, CancellationToken cancellationToken)
    {
        var hotel = _hotelRepository.Fetch(command.Id);
        if (hotel is null) return Errors.Hotel.HotelNotFound;

        _hotelRepository.Delete((Hotel)hotel);
        _hotelRepository.Save();

        return new HotelResult((Hotel)hotel);
    }
}