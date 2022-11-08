using AirBNB.Authentication.Service.Entities;

namespace AirBNB.Authentication.Service.Interfaces
{
    public interface ITokenRepository
    {
        Task Create(VerificationToken verificationToken);

        Task<VerificationToken> FindByToken(string token);

        void Delete(VerificationToken verificationToken);

        Task Save();
    }
}