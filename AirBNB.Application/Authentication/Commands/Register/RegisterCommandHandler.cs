using AirBNB.Application.Authentication.Common;
using AirBNB.Application.Common.Interfaces.Authentication;
using AirBNB.Application.Common.Interfaces.Persistence;
using AirBNB.Domain.Common.Errors;
using AirBNB.Domain.Users;
using ErrorOr;
using MediatR;

namespace AirBNB.Application.Authentication.Commands.Register;

public class RegisterCommandHandler :
    IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        var user = User.Create(
            command.FirstName,
            command.LastName,
            command.Email,
            command.Password);

        _userRepository.Add(user);
        _userRepository.Save();

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}