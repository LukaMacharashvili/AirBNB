using AirBNB.Application.Rooms.Common;
using AirBNB.Application.Common.Interfaces.Persistence;
using AirBNB.Domain.Rooms;
using ErrorOr;
using MediatR;

namespace AirBNB.Application.Rooms.Commands.CreateRoom;

public class CreateRoomCommandHandler :
    IRequestHandler<CreateRoomCommand, ErrorOr<RoomResult>>
{
    private readonly IRoomRepository _roomRepository;

    public CreateRoomCommandHandler(IRoomRepository roomRepository)
    {
        _roomRepository = roomRepository;
    }

    public async Task<ErrorOr<RoomResult>> Handle(CreateRoomCommand command, CancellationToken cancellationToken)
    {
        var room = Room.Create(
            command.HotelId,
            command.Name,
            command.ImageUrl);

        _roomRepository.Add(room);
        _roomRepository.Save();

        return new RoomResult(room);
    }
}