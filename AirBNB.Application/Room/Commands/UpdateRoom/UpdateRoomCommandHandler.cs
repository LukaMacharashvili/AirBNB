using AirBNB.Application.Rooms.Common;
using AirBNB.Application.Common.Interfaces.Persistence;
using AirBNB.Domain.Common.Errors;
using AirBNB.Domain.Rooms;
using ErrorOr;
using MediatR;

namespace AirBNB.Application.Rooms.Commands.UpdateRoom;

public class UpdateRoomCommandHandler :
    IRequestHandler<UpdateRoomCommand, ErrorOr<RoomResult>>
{
    private readonly IRoomRepository _roomRepository;

    public UpdateRoomCommandHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<ErrorOr<RoomResult>> Handle(UpdateRoomCommand command, CancellationToken cancellationToken)
    {
        var room = _roomRepository.Fetch(command.Id);
        if (room is null) return Errors.Room.RoomNotFound;

        room.Name = command.Name;
        room.ImageUrl = command.ImageUrl;
        _roomRepository.Save();

        return new RoomResult((Room)room);
    }
}