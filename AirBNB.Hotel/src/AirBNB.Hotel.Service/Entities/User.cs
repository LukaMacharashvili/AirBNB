namespace AirBNB.Hotels.Service.Entities
{
    public class User
    {
        public User() { }
        public User(string name, string role)
        {
            Name = name;
            Role = role;
        }

        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Role { get; set; } = string.Empty;
    }
}