using AirBNB.Application.Common.Interfaces.Services;

namespace AirBNB.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}