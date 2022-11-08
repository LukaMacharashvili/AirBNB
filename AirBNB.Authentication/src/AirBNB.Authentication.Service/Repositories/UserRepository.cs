using AirBNB.Authentication.Service.Data;
using AirBNB.Authentication.Service.Entities;
using AirBNB.Authentication.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AirBNB.Authentication.Service.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Create(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> FindUserByEmail(string email)
        {
            return await _context.Set<User>().Where(x => x.Email == email).FirstOrDefaultAsync();
        }

        public async Task<User> Fetch(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}