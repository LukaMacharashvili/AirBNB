using AirBNB.Domain.Users;

namespace AirBNB.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}