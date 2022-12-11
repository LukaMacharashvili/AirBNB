namespace AirBNB.Contracts.Hotels;

public record CreateHotelRequest(
    string Name,
    string ImageUrl);