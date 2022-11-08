using AirBNB.Hotels.Service.Data;
using AirBNB.Hotels.Service.Entities;
using AirBNB.Hotels.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AirBNB.Hotels.Service.Repositories
{
    public class BookDateRepository : IBookDateRepository
    {
        private readonly DataContext _context;

        public BookDateRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<BookDate>> Load(int roomId)
        {
            return await _context.Set<BookDate>().Where(x => x.RoomId == roomId).ToListAsync();
        }

        public async Task Create(BookDate hotel)
        {
            await _context.BookDates.AddAsync(hotel);
            await _context.SaveChangesAsync();
        }

        public async Task<BookDate> Fetch(int id)
        {
            return await _context.BookDates.FindAsync(id);
        }

        public void Delete(BookDate hotel)
        {
            _context.BookDates.Remove(hotel);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}