using AirBNB.Application.Common.Interfaces.Persistence;
using AirBNB.Infrastructure.Data;
using AirBNB.Domain.BookDates;

namespace AirBNB.Infrastructure.Persistence;

public sealed class BookDateRepository : IBookDateRepository
{
    private readonly DataContext _context;
    public BookDateRepository(DataContext context)
    {
        _context = context;
    }

    public void Add(List<BookDate> bookDates)
    {
        _context.BookDate.AddRange(bookDates);
    }

    public void Delete(List<BookDate> bookDates)
    {
        _context.BookDate.RemoveRange(bookDates);
    }

    public BookDate? Fetch(string id)
    {
        return _context.BookDate.Find(id);
    }

    public List<BookDate>? Load(string roomId)
    {
        return _context.BookDate.Where(x => x.RoomId == roomId).ToList();
    }

    public List<BookDate>? SearchByDateRange(string roomId, DateOnly startDate, DateOnly endDate)
    {
        return _context.BookDate.Where(x => x.RoomId == roomId && x.Date >= startDate && x.Date <= endDate).ToList();
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}