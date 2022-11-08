using AirBNB.Authentication.Service.Data;
using AirBNB.Authentication.Service.Entities;
using AirBNB.Authentication.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AirBNB.Authentication.Service.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly DataContext _context;

        public TokenRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Create(VerificationToken verificationToken)
        {
            _context.VerificationTokens.Add(verificationToken);
            await _context.SaveChangesAsync();
        }

        public async Task<VerificationToken> FindByToken(string token)
        {
            return await _context.Set<VerificationToken>().Where(x => x.Token == token).FirstOrDefaultAsync();
        }

        public void Delete(VerificationToken verificationToken)
        {
            _context.VerificationTokens.Remove(verificationToken);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}