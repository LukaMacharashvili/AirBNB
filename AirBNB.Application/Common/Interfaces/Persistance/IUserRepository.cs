using AirBNB.Domain.Users;

namespace AirBNB.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    void Save();
    List<User>? Load();
    User? Fetch(string id);
    void Add(User user);
    void Delete(User user);
    User? GetUserByEmail(string email);
}