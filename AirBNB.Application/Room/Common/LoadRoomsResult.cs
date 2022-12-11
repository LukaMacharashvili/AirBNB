using AirBNB.Domain.Rooms;

namespace AirBNB.Application.Rooms.Common;

public record LoadRoomsResult(List<Room> Rooms);