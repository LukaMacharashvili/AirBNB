using AirBNB.Application.Rooms.Common;
using ErrorOr;
using MediatR;

namespace AirBNB.Application.Rooms.Queries.FetchRoom;

public record FetchRoomQuery(string Id) : IRequest<ErrorOr<RoomResult>>;