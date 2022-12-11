using AirBNB.Domain.Rooms;

namespace AirBNB.Application.Common.Interfaces.Persistence;

public interface IRoomRepository
{
    void Save();
    List<Room>? Load(string HotelId);
    Room? Fetch(string id);
    void Add(Room room);
    void Delete(Room room);
}