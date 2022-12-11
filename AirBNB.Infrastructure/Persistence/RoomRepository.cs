using AirBNB.Application.Common.Interfaces.Persistence;
using AirBNB.Domain.Rooms;
using AirBNB.Infrastructure.Data;

namespace AirBNB.Infrastructure.Persistence;

public sealed class RoomRepository : IRoomRepository
{
    private readonly DataContext _context;
    public RoomRepository(DataContext context)
    {
        _context = context;
    }

    public void Add(Room room)
    {
        _context.Room.Add(room);
    }

    public void Delete(Room room)
    {
        _context.Room.Remove(room);
    }

    public Room? Fetch(string id)
    {
        return _context.Room.Find(id);
    }

    public List<Room>? Load(string hotelId)
    {
        return _context.Room.Where(x => x.HotelId == hotelId).ToList();
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}