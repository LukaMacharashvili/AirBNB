using System.Security.Cryptography;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using AirBNB.Admin.Service.Entities;

namespace AirBNB.Admin.Service.Helpers
{
    public class PasswordHelpers
    {
        private readonly IConfiguration _configuration;

        public PasswordHelpers(IConfiguration configuration)
        {
            _configuration = configuration;

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