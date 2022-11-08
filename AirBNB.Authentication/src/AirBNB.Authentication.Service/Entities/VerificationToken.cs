namespace AirBNB.Authentication.Service.Entities
{
    public class VerificationToken
    {
        public VerificationToken() { }

        public VerificationToken(string token, int userId)
        {
            Token = token;
            UserId = userId;
        }

        public int Id { get; set; }
        public string? Token { get; set; } = string.Empty;

        public int UserId { get; set; }
        public User User { get; set; }
    }
}