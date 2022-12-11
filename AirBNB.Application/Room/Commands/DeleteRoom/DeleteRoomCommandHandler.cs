using AirBNB.Application.Rooms.Common;
using AirBNB.Application.Common.Interfaces.Persistence;
using AirBNB.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace AirBNB.Application.Rooms.Commands.DeleteRoom;
public class DeleteRoomCommandHandler :
    IRequestHandler<DeleteRoomCommand, ErrorOr<RoomResult>>
{
    private readonly IRoomRepository _roomRepository;

    public DeleteRoomCommandHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<ErrorOr<RoomResult>> Handle(DeleteRoomCommand command, CancellationToken cancellationToken)
    {
        var room = _roomRepository.Fetch(command.Id);
        if (room is null) return Errors.Room.RoomNotFound;

        _roomRepository.Delete(room);
        _roomRepository.Save();

        return new RoomResult(room);
    }
}