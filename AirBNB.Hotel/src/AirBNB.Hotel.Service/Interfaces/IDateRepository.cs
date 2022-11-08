using AirBNB.Hotels.Service.Entities;

namespace AirBNB.Hotels.Service.Interfaces
{
    public interface IBookDateRepository
    {
        Task<List<BookDate>> Load(int id);

        Task Create(BookDate date);

        Task<BookDate> Fetch(int id);

        void Delete(BookDate date);

        Task Save();
    }
}