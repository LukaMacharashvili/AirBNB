using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using AirBNB.Authentication.Service.Entities;

namespace AirBNB.Authentication.Service.Helpers
{
    public class PasswordHelpers
    {
        private readonly IConfiguration _configuration;

        public PasswordHelpers(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
        public void CreatePasswordHash(string password, out string passwordHash)
        {
            var sha = SHA256.Create();
            passwordHash = Convert.ToBase64String(sha.ComputeHash(System.Text.Encoding.Default.GetBytes(password)));
        }

        public bool VerifyPasswordHash(string passwordToCheck, string password)
        {
            CreatePasswordHash(passwordToCheck, out string passwordHash);
            return password == passwordHash;
        }
    }
}