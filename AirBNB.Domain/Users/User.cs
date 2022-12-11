namespace AirBNB.Domain.Users;

public sealed class User
{
    public string Id { get; set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }
    private User() { }

    public static User Create(
        string firstName,
        string lastName,
        string email,
        string password)
    {
        return new User
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };
    }
}