using AirBNB.Admin.Service.Entities;
using AirBNB.Admin.Service.Helpers;
using AirBNB.Admin.Service.Dtos;
using AirBNB.Admin.Service.Interfaces;

namespace AirBNB.Admin.Service.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly PasswordHelpers _passwordHelpers;

        public UserService(IUserRepository userRepository, PasswordHelpers passwordHelpers)
        {
            _userRepository = userRepository;
            _passwordHelpers = passwordHelpers;
        }

        public async Task<User> Fetch(int id)
        {
            return await _userRepository.Fetch(id);
        }

        public async Task<List<User>> Load()
        {
            return await _userRepository.Load();
        }

        public async Task<User> Create(CreateUserDto createUserDto)
        {
            var user = new User(createUserDto.Name, createUserDto.LastName, createUserDto.Email, createUserDto.Password, createUserDto.Role, createUserDto.Balance);

            var emailUser = await _userRepository.FindUserByEmail(user.Email);
            if (emailUser != null) throw new BadHttpRequestException("Email Already Exists");

            _passwordHelpers.CreatePasswordHash(user.Password, out string passwordHash);
            user.Password = passwordHash;
            await this._userRepository.Create(user);

            return user;
        }

        public async Task VerifyUser(int id)
        {
            var user = await _userRepository.Fetch(id);

            user.Verified = true;
            await _userRepository.Save();
        }

        public async Task Delete(int id)
        {
            var user = await _userRepository.Fetch(id);
            if (user == null) throw new BadHttpRequestException("User Not Found");

            _userRepository.Delete(user);
            await _userRepository.Save();
        }

        public async Task<User> UpdateUser(int id, UpdateUserDto updateDto)
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
            if (updateDto.Role != null) user.Role = updateDto.Role;
            if (!updateDto.Balance.Equals(null)) user.Balance = updateDto.Balance;
            if (updateDto.Email != user.Email && updateDto.Email != null)
            {
                var emailUser = await _userRepository.FindUserByEmail(updateDto.Email);
                if (emailUser != null) throw new BadHttpRequestException("Email Already Exists");
                user.Email = updateDto.Email;
            }

            await _userRepository.Save();
            return user;
        }
    }
}
