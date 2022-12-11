using AirBNB.Application.BookDates.Common;
using AirBNB.Application.Common.Interfaces.Persistence;
using AirBNB.Domain.BookDates;
using ErrorOr;
using MediatR;

namespace AirBNB.Application.BookDates.Queries.LoadBookDates;

public class LoadBookDatesQueryHandler :
    IRequestHandler<LoadBookDatesQuery, ErrorOr<LoadBookDatesResult>>
{
    private readonly IBookDateRepository _bookDateRepository;

    public LoadBookDatesQueryHandler(IBookDateRepository bookDateRepository)
    {
        _bookDateRepository = bookDateRepository;
    }

    public async Task<ErrorOr<LoadBookDatesResult>> Handle(LoadBookDatesQuery query, CancellationToken cancellationToken)
    {
        var BookDates = _bookDateRepository.Load(query.RoomId);
        if (BookDates is null) return new LoadBookDatesResult(new List<BookDate>());

        return new LoadBookDatesResult(BookDates);
    }
}