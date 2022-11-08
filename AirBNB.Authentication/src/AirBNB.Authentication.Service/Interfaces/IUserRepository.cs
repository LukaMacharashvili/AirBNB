using AirBNB.Authentication.Service.Entities;

namespace AirBNB.Authentication.Service.Interfaces
{
    public interface IUserRepository
    {
        Task Create(User user);

        Task<User> FindUserByEmail(string email);

        Task<User> Fetch(int id);

        void Delete(User user);

        Task Save();
    }
}