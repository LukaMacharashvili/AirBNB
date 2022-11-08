namespace AirBNB.Authentication.Service.Dtos
{
    public record RegisterDto(string Name, string LastName, string Email, string Password);
    public record UpdateDto(string? Name, string? LastName, string? Email, string? Password);
    public record LoginDto(string Email, string Password);
}