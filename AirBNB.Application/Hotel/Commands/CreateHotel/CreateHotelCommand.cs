using AirBNB.Application.Hotels.Common;
using ErrorOr;
using MediatR;

namespace AirBNB.Application.Hotels.Commands.CreateHotel;

public record CreateHotelCommand(
    string Name,
    string ImageUrl,
    string UserId) : IRequest<ErrorOr<HotelResult>>;