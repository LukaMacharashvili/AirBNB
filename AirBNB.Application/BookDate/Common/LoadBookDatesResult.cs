using AirBNB.Domain.BookDates;

namespace AirBNB.Application.BookDates.Common;

public record LoadBookDatesResult(List<BookDate> BookDates);