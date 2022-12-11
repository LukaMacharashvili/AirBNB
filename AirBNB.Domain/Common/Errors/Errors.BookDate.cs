using ErrorOr;

namespace AirBNB.Domain.Common.Errors;

public static partial class Errors
{
    public static class BookDate
    {
        public static Error BookDateNotFound => Error.NotFound(
            code: "BookDate.BookDateNotFound",
            description: "BookDate Not Found");
    }
}