using System.Security.Cryptography;
using EventBus.Contracts;
using AirBNB.Authentication.Service.Dtos;
using AirBNB.Authentication.Service.Entities;
using AirBNB.Authentication.Service.Helpers;
using MassTransit;
using AirBNB.Authentication.Service.Interfaces;

namespace AirBNB.Authentication.Service.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly PasswordHelpers _passwordHelpers;
        private readonly ITokenRepository _tokenRepository;
        private readonly IPublishEndpoint _publishEndpoint;

        public UserService(IUserRepository userRepository, IConfiguration configuration, PasswordHelpers passwordHelpers, ITokenRepository tokenRepository, IPublishEndpoint publishEndpoint)
        {
            _userRepository = userRepository;
            _passwordHelpers = passwordHelpers;
            _tokenRepository = tokenRepository;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<User> Fetch(int id)
        {
            return await _userRepository.Fetch(id);
        }

        public async Task<User> RegisterUser(RegisterDto registerDto)
        {
            var user = new User(registerDto.Name, registerDto.LastName, registerDto.Email, registerDto.Password, "User", 0);

            var emailUser = await _userRepository.FindUserByEmail(user.Email);
            if (emailUser != null) throw new BadHttpRequestException("Email Already Exists");

            _passwordHelpers.CreatePasswordHash(user.Password, out string passwordHash);
            user.Password = passwordHash;
            await this._userRepository.Create(user);
            string verificationToken = Convert.ToBase64String(SHA256.Create().ComputeHash(System.Text.Encoding.Default.GetBytes(user.Email)));
            await this._tokenRepository.Create(new VerificationToken(verificationToken, user.Id));

            await _publishEndpoint.Publish(new UserRegistered(user.Email, verificationToken));
            return user;
        }

        public async Task<string> LoginUser(LoginDto loginDto)
        {
            var user = new User(loginDto.Email, loginDto.Password);

            var userExists = await _userRepository.FindUserByEmail(user.Email);
            if (userExists == null) throw new BadHttpRequestException("Provided Email or Password Is Incorrect");
            if (!userExists.Verified) throw new BadHttpRequestException("User Is Not Verified");

            if (_passwordHelpers.VerifyPasswordHash(user.Password, userExists.Password)) return _passwordHelpers.CreateToken(userExists);
            throw new BadHttpRequestException("Provided Email or Password Is Incorrect");
        }

        public async Task VerifyUser(string verificationToken)
        {
            var token = await _tokenRepository.FindByToken(verificationToken);

            var user = await _userRepository.Fetch(token.UserId);
            user.Verified = true;
            await _userRepository.Save();

            _tokenRepository.Delete(token);
            await _tokenRepository.Save();
        }

        public async Task DeleteUser(int id)
        {
            var user = await _userRepository.Fetch(id);
            if (user == null) throw new BadHttpRequestException("User Not Found");

            _userRepository.Delete(user);
            await _userRepository.Save();
        }

        public async Task<User> UpdateUser(int id, UpdateDto updateDto)
        {
            var user = await _userRepository.Fetch(id);
            if (user == null) throw new BadHttpRequestException("User Not Found");

            if (updateDto.Password != null)
            {
                _passwordHelpers.CreatePasswordHash(updateDto.Password, out string passwordHash);
                user.Password = passwordHash;
            }
            if (updateDto.Name != null) user.Name = updateDto.Name;
            if (updateDto.LastName != null) user.LastName = updateDto.LastName;
            if (updateDto.Email != user.Email && updateDto.Email != null)
            {
                var emailUser = await _userRepository.FindUserByEmail(updateDto.Email);
                if (emailUser != null) throw new BadHttpRequestException("Email Already Exists");
                string verificationToken = Convert.ToBase64String(SHA256.Create().ComputeHash(System.Text.Encoding.Default.GetBytes(updateDto.Email)));
                await this._tokenRepository.Create(new VerificationToken(verificationToken, user.Id));
                await _publishEndpoint.Publish(new UserUpdated(updateDto.Email, verificationToken));
                user.Email = updateDto.Email;
                user.Verified = false;
            }

            await _userRepository.Save();
            return user;
        }
    }
}