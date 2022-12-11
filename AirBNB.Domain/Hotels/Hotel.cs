namespace AirBNB.Domain.Hotels;

public sealed class Hotel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string UserId { get; set; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
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