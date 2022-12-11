using AirBNB.Application.Rooms.Common;
using ErrorOr;
using MediatR;

namespace AirBNB.Application.Rooms.Commands.UpdateRoom;

public record UpdateRoomCommand(
    string Name,
    string ImageUrl,
    string Id) : IRequest<ErrorOr<RoomResult>>;