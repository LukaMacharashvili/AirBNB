using AirBNB.Domain.Rooms;

namespace AirBNB.Domain.BookDates;

public sealed class BookDate
{
    public string Id { get; set; }
    public DateOnly Date { get; set; }

    public string RoomId { get; set; }
    public Room Room { get; set; }

    private BookDate() { }
    public static BookDate Create(
        string roomId,
        DateOnly date)
    {
        return new BookDate()
        {
            Id = Guid.NewGuid().ToString(),
            RoomId = roomId,
            Date = date,
        };
    }
}