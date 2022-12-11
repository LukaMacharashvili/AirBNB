using AirBNB.Domain.Hotels;

namespace AirBNB.Application.Common.Interfaces.Persistence;

public interface IHotelRepository
{
    void Save();
    List<Hotel>? Load();
    Hotel? Fetch(string id);
    void Add(Hotel hotel);
    void Delete(Hotel hotel);
}