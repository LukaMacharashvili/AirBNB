using AirBNB.Application.Hotels.Common;
using ErrorOr;
using MediatR;

namespace AirBNB.Application.Hotels.Commands.DeleteHotel;

public record DeleteHotelCommand(string Id) : IRequest<ErrorOr<HotelResult>>;