using AirBNB.Application.Rooms.Common;
using ErrorOr;
using MediatR;

namespace AirBNB.Application.Rooms.Commands.DeleteRoom;

public record DeleteRoomCommand(string Id) : IRequest<ErrorOr<RoomResult>>;