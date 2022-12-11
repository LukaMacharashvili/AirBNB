using AirBNB.Application.Common.Interfaces.Persistence;
using AirBNB.Domain.Hotels;
using AirBNB.Infrastructure.Data;

namespace AirBNB.Infrastructure.Persistence;

public sealed class HotelRepository : IHotelRepository
{
    private readonly DataContext _context;
    public HotelRepository(DataContext context)
    {
        _context = context;
    }

    public void Add(Hotel hotel)
    {
        _context.Hotel.Add(hotel);
    }

    public void Delete(Hotel hotel)
    {
        _context.Hotel.Remove(hotel);
    }

    public Hotel? Fetch(string id)
    {
        return _context.Hotel.Find(id);
    }

    public List<Hotel>? Load()
    {
        return _context.Hotel.ToList();
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}