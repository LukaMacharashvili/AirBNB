using AirBNB.Domain.BookDates;
using AirBNB.Domain.Hotels;

namespace AirBNB.Domain.Rooms;

public sealed class Room
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public string HotelId { get; set; }
    public Hotel Hotel { get; set; }

    public List<BookDate>? BookDates { get; set; }

    private Room() { }
    public static Room Create(
        string hotelId,
        string name,
        string imageUrl)
    {
        return new Room
        {
            Id = Guid.NewGuid().ToString(),
            HotelId = hotelId,
            Name = name,
            ImageUrl = imageUrl
        };
    }
}