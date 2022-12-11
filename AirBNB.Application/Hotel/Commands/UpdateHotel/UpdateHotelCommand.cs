using AirBNB.Application.Hotels.Common;
using ErrorOr;
using MediatR;

namespace AirBNB.Application.Hotels.Commands.UpdateHotel;

public record UpdateHotelCommand(
    string Name,
    string ImageUrl,
    string Id) : IRequest<ErrorOr<HotelResult>>;