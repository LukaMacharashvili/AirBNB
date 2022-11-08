namespace AirBNB.Hotels.Service.Entities
{
    public class Room
    {
        public Room() { }
        public Room(string name, string image, int hotelId, int userId)
        {
            Name = name;
            Image = image;
            HotelId = hotelId;
            UserId = userId;
        }

        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;

        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

    }
}