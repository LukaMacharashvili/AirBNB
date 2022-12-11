namespace AirBNB.Domain.BookDates;

public sealed class BookDate
{
    public string Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string RoomId { get; set; }
    private BookDate() { }

    public static BookDate Create(
        string roomId,
        DateTime startDate,
        DateTime endDate)
    {
        return new BookDate()
        {
            Id = Guid.NewGuid().ToString(),
            RoomId = roomId,
            StartDate = startDate,
            EndDate = endDate
        };
    }
}