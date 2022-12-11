using AirBNB.Application.Hotels.Common;
using AirBNB.Application.Common.Interfaces.Persistence;
using AirBNB.Domain.Common.Errors;
using AirBNB.Domain.Hotels;
using ErrorOr;
using MediatR;

namespace AirBNB.Application.Hotels.Queries.FetchHotel;

public class FetchHotelQueryHandler :
    IRequestHandler<FetchHotelQuery, ErrorOr<HotelResult>>
{
    private readonly IHotelRepository _hotelRepository;

    public FetchHotelQueryHandler(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    public async Task<ErrorOr<HotelResult>> Handle(FetchHotelQuery query, CancellationToken cancellationToken)
    {
        var hotel = _hotelRepository.Fetch(query.Id);
        if (hotel is null) return Errors.Hotel.HotelNotFound;

        return new HotelResult((Hotel)hotel);
    }
}