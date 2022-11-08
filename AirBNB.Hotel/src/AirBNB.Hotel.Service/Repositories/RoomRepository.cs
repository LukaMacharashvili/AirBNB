using AirBNB.Hotels.Service.Data;
using AirBNB.Hotels.Service.Entities;
using AirBNB.Hotels.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AirBNB.Hotels.Service.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DataContext _context;

        public RoomRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Room>> Load(int hotelId)
        {
            return await _context.Set<Room>().Where(x => x.HotelId == hotelId).ToListAsync();
        }

        public async Task Create(Room room)
        {
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
        }

        public async Task<Room> Fetch(int id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public void Delete(Room room)
        {
            _context.Rooms.Remove(room);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}