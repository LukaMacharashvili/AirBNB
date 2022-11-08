namespace AirBNB.Admin.Service.Entities
{
    public class User
    {

        public User() { }

        public User(string name, string lastName, string email, string password, string role, float balance)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;
            Role = role;
            Balance = balance;
        }

        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? Role { get; set; } = string.Empty;
        public bool Verified { get; set; } = false;
        public float? Balance { get; set; } = 0;
    }
}