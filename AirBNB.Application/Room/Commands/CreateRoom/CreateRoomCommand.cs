using AirBNB.Application.Rooms.Common;
using ErrorOr;
using MediatR;

namespace AirBNB.Application.Rooms.Commands.CreateRoom;

public record CreateRoomCommand(
    string Name,
    string ImageUrl,
    string HotelId) : IRequest<ErrorOr<RoomResult>>;