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
        var bookDate = _bookDateRepository.Fetch(command.Id);
        if (bookDate is null) return Errors.BookDate.BookDateNotFound;

        _bookDateRepository.Delete((BookDate)bookDate);
        _bookDateRepository.Save();

        return new BookDateResult((BookDate)bookDate);
    }
}