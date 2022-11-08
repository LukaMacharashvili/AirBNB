using AirBNB.Hotels.Service.Entities;

namespace AirBNB.Hotels.Service.Interfaces
{
    public interface IHotelRepository
    {
        Task<List<Hotel>> Load(int adminId);

        Task Create(Hotel hotel);

        Task<Hotel> Fetch(int id);

        void Delete(Hotel hotel);

        Task Save();
    }
}