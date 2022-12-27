using AirBNB.Application.BookDates.Common;
using AirBNB.Application.Common.Interfaces.Persistence;
using AirBNB.Domain.Common.Errors;
using AirBNB.Domain.BookDates;
using ErrorOr;
using MediatR;

namespace AirBNB.Application.BookDates.Commands.UnbookRoom;
public class UnbookRoomCommandHandler :
    IRequestHandler<UnbookRoomCommand, ErrorOr<BookDateResult>>
{
    private readonly IBookDateRepository _bookDateRepository;

    public UnbookRoomCommandHandler(IBookDateRepository bookDateRepository)
    {
        _bookDateRepository = bookDateRepository;
    }

    public async Task<ErrorOr<BookDateResult>> Handle(UnbookRoomCommand command, CancellationToken cancellationToken)
    {
        var bookDates = _bookDateRepository.SearchByDateRange(command.RoomId, command.StartDate, command.EndDate);
        if (bookDates is null) return Errors.BookDate.BookDateNotFound;

        _bookDateRepository.Delete(bookDates);
        _bookDateRepository.Save();

        return new BookDateResult(command.StartDate, command.EndDate, command.RoomId);
    }
}