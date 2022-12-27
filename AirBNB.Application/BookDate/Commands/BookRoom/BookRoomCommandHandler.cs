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
        List<BookDate> bookDates = new List<BookDate>();
        var startDate = command.StartDate;

        while (startDate <= command.EndDate)
        {
            var bookDate = BookDate.Create(
                command.RoomId,
                startDate);

            bookDates.Add(bookDate);
            startDate = startDate.AddDays(1);
        }

        _bookDateRepository.Add(bookDates);
        _bookDateRepository.Save();

        return new BookDateResult(command.StartDate, command.EndDate, command.RoomId);
    }
}