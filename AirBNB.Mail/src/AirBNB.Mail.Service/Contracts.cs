namespace EventBus.Contracts
{
    public record UserRegistered(string Email, string VerificationToken);
    public record UserUpdated(string Email, string VerificationToken);
}