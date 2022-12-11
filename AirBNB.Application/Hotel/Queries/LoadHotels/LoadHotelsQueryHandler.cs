using AirBNB.Application.Hotels.Common;
using AirBNB.Application.Common.Interfaces.Persistence;
using AirBNB.Domain.Hotels;
using ErrorOr;
using MediatR;

namespace AirBNB.Application.Hotels.Queries.LoadHotels;

public class LoadHotelsQueryHandler :
    IRequestHandler<LoadHotelsQuery, ErrorOr<LoadHotelsResult>>
{
    private readonly IHotelRepository _hotelRepository;

    public LoadHotelsQueryHandler(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    public async Task<ErrorOr<LoadHotelsResult>> Handle(LoadHotelsQuery query, CancellationToken cancellationToken)
    {
        var hotels = _hotelRepository.Load();
        if (hotels is null) return new LoadHotelsResult(new List<Hotel>());

        return new LoadHotelsResult(hotels);
    }
}