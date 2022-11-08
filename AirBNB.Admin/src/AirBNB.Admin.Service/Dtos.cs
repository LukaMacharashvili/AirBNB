namespace AirBNB.Admin.Service.Dtos
{
    public record CreateUserDto(string Name, string LastName, string Email, string Password, string Role, float Balance);
    public record UpdateUserDto(string? Name, string? LastName, string? Email, string? Password, string? Role, float? Balance);
}