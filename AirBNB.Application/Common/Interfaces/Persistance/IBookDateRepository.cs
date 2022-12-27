using AirBNB.Domain.BookDates;

namespace AirBNB.Application.Common.Interfaces.Persistence;

public interface IBookDateRepository
{
    void Save();
    List<BookDate>? Load(string roomId);
    BookDate? Fetch(string id);
    void Add(List<BookDate> bookDates);
    void Delete(List<BookDate> bookDates);
    List<BookDate>? SearchByDateRange(string roomId, DateOnly startDate, DateOnly endDate);
}