using AirBNB.Application.Rooms.Common;
using AirBNB.Application.Common.Interfaces.Persistence;
using AirBNB.Domain.Rooms;
using ErrorOr;
using MediatR;

namespace AirBNB.Application.Rooms.Queries.LoadRooms;

public class LoadRoomsQueryHandler :
    IRequestHandler<LoadRoomsQuery, ErrorOr<LoadRoomsResult>>
{
    private readonly IRoomRepository _roomRepository;

    public LoadRoomsQueryHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<ErrorOr<LoadRoomsResult>> Handle(LoadRoomsQuery query, CancellationToken cancellationToken)
    {
        var Rooms = _roomRepository.Load(query.HotelId);
        if (Rooms is null) return new LoadRoomsResult(new List<Room>());

        return new LoadRoomsResult(Rooms);
    }
}