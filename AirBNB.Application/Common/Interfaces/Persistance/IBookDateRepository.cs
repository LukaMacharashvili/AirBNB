using AirBNB.Domain.BookDates;

namespace AirBNB.Application.Common.Interfaces.Persistence;

public interface IBookDateRepository
{
    void Save();
    List<BookDate>? Load(string roomId);
    BookDate? Fetch(string id);
    void Add(BookDate bookDate);
    void Delete(BookDate bookDate);
}