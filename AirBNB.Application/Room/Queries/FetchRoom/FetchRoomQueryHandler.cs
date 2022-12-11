using AirBNB.Application.Rooms.Common;
using AirBNB.Application.Common.Interfaces.Persistence;
using AirBNB.Domain.Common.Errors;
using AirBNB.Domain.Rooms;
using ErrorOr;
using MediatR;

namespace AirBNB.Application.Rooms.Queries.FetchRoom;

public class FetchRoomQueryHandler :
    IRequestHandler<FetchRoomQuery, ErrorOr<RoomResult>>
{
    private readonly IRoomRepository _roomRepository;

    public FetchRoomQueryHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<ErrorOr<RoomResult>> Handle(FetchRoomQuery query, CancellationToken cancellationToken)
    {
        var room = _roomRepository.Fetch(query.Id);
        if (room is null) return Errors.Room.RoomNotFound;

        return new RoomResult((Room)room);
    }
}