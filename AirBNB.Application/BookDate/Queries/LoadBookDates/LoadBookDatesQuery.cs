using AirBNB.Application.BookDates.Common;
using ErrorOr;
using MediatR;

namespace AirBNB.Application.BookDates.Queries.LoadBookDates;

public record LoadBookDatesQuery(string RoomId) : IRequest<ErrorOr<LoadBookDatesResult>>;