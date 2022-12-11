using AirBNB.Application.Common.Interfaces.Persistence;
using AirBNB.Domain.Users;
using AirBNB.Infrastructure.Data;

namespace AirBNB.Infrastructure.Persistence;

public sealed class UserRepository : IUserRepository
{
    private readonly DataContext _context;
    public UserRepository(DataContext context)
    {
        _context = context;
    }

    public void Add(User user)
    {
        _context.User.Add(user);
    }

    public void Delete(User user)
    {
        _context.User.Remove(user);
    }

    public User? Fetch(string id)
    {
        return _context.User.Find(id);
    }

    public User? GetUserByEmail(string email)
    {
        return _context.User.Where(x => x.Email == email).FirstOrDefault();
    }

    public List<User>? Load()
    {
        return _context.User.ToList();
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}