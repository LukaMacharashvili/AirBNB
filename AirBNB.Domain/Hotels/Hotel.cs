using AirBNB.Domain.Rooms;
using AirBNB.Domain.Users;

namespace AirBNB.Domain.Hotels;

public sealed class Hotel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public string UserId { get; set; }
    public User User { get; set; }

    public List<Room>? Rooms { get; set; }

    private Hotel() { }
    public static Hotel Create(
        string userId,
        string name,
        string imageUrl)
    {
        return new Hotel
        {
            Id = Guid.NewGuid().ToString(),
            UserId = userId,
            Name = name,
            ImageUrl = imageUrl
        };
    }
}