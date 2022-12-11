using AirBNB.Domain.Users;

namespace AirBNB.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);