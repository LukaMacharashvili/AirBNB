using AirBNB.Hotels.Service.Data;
using AirBNB.Hotels.Service.Entities;
using AirBNB.Hotels.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AirBNB.Hotels.Service.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly DataContext _context;

        public HotelRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Hotel>> Load(int adminId)
        {
            return await _context.Set<Hotel>().Where(x => x.UserId == adminId).ToListAsync();
        }

        public async Task Create(Hotel hotel)
        {
            await _context.Hotels.AddAsync(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task<Hotel> Fetch(int id)
        {
            return await _context.Hotels.FindAsync(id);
        }

        public void Delete(Hotel hotel)
        {
            _context.Hotels.Remove(hotel);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}