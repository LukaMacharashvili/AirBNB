namespace AirBNB.Hotels.Service.Entities
{
    public class Hotel
    {
        public Hotel() { }
        public Hotel(string name, string image, int userId)
        {
            Name = name;
            Image = image;
            UserId = userId;
        }

        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Image { get; set; } = string.Empty;


        public int UserId { get; set; }
        public User User { get; set; }

    }
}