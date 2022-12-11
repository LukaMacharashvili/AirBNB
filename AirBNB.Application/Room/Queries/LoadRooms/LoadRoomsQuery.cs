using AirBNB.Application.Rooms.Common;
using ErrorOr;
using MediatR;

namespace AirBNB.Application.Rooms.Queries.LoadRooms;

public record LoadRoomsQuery(string HotelId) : IRequest<ErrorOr<LoadRoomsResult>>;