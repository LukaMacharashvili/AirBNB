using AirBNB.Application.Hotels.Common;
using ErrorOr;
using MediatR;

namespace AirBNB.Application.Hotels.Queries.LoadHotels;

public record LoadHotelsQuery() : IRequest<ErrorOr<LoadHotelsResult>>;