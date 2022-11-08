namespace AirBNB.Hotels.Service.Dtos
{
    public record CreateHotelDto(string Name, string Image);
    public record UpdateHotelDto(string Name, string Image);

    public record CreateRoomDto(string Name, string Image, int HotelId);
    public record UpdateRoomDto(string Name, string Image);

    public record CreateBookDto(DateTime StartDate, DateTime EndDate);
}