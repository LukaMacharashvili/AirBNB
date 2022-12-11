namespace AirBNB.Contracts.Hotels;

public record HotelResponse(
    Guid Id,
    string Name,
    string ImageUrl,
    string UserId);