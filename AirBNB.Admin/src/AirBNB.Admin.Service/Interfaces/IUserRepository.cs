using AirBNB.Admin.Service.Entities;

namespace AirBNB.Admin.Service.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> Load();

        Task Create(User user);

        Task<User> FindUserByEmail(string email);

        Task<User> Fetch(int id);

        void Delete(User user);

        Task Save();
    }
}