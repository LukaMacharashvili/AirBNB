using AirBNB.Application.BookDates.Common;
using AirBNB.Application.Common.Interfaces.Persistence;
using AirBNB.Domain.BookDates;
using ErrorOr;
using MediatR;

namespace AirBNB.Application.BookDates.Commands.BookRoom;

public class BookRoomCommandHandler :
    IRequestHandler<BookRoomCommand, ErrorOr<BookDateResult>>
{
    private readonly IBookDateRepository _bookDateRepository;

    public BookRoomCommandHandler(IBookDateRepository bookDateRepository)
    {
        _bookDateRepository = bookDateRepository;
    }

    public async Task<ErrorOr<BookDateResult>> Handle(BookRoomCommand command, CancellationToken cancellationToken)
    {
        var bookDate = BookDate.Create(
            command.RoomId,
            command.StartDate,
            command.EndDate);

        _bookDateRepository.Add(bookDate);
        _bookDateRepository.Save();

        return new BookDateResult(bookDate);
    }
}