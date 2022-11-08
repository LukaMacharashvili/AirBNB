using AirBNB.Hotels.Service.Entities;

namespace AirBNB.Hotels.Service.Interfaces
{
    public interface IRoomRepository
    {
        Task<List<Room>> Load(int hotelId);

        Task Create(Room room);

        Task<Room> Fetch(int id);

        void Delete(Room room);

        Task Save();
    }
}