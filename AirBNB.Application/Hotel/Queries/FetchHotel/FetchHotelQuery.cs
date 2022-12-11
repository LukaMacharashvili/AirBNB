using AirBNB.Application.Hotels.Common;
using ErrorOr;
using MediatR;

namespace AirBNB.Application.Hotels.Queries.FetchHotel;

public record FetchHotelQuery(string Id) : IRequest<ErrorOr<HotelResult>>;