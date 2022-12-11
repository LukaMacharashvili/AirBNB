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

    public void Add(BookDate bookDate)
    {
        _context.BookDate.Add(bookDate);
    }

    public void Delete(BookDate bookDate)
    {
        _context.BookDate.Remove(bookDate);
    }

    public BookDate? Fetch(string id)
    {
        return _context.BookDate.Find(id);
    }

    public List<BookDate>? Load(string roomId)
    {
        return _context.BookDate.Where(x => x.RoomId == roomId).ToList();
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}