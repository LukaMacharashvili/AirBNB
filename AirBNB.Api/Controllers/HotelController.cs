using System.Security.Claims;
using AirBNB.Application.Hotels.Commands.CreateHotel;
using AirBNB.Application.Hotels.Commands.DeleteHotel;
using AirBNB.Application.Hotels.Commands.UpdateHotel;
using AirBNB.Application.Hotels.Queries.FetchHotel;
using AirBNB.Application.Hotels.Queries.LoadHotels;
using AirBNB.Contracts.Hotels;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirBNB.Api.Controllers;

[Route("hotel")]
public class HotelController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;
    private readonly string UserId;

    public HotelController(ISender mediator, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _mediator = mediator;
        _mapper = mapper;
        UserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
    }

    [HttpGet("")]
    public async Task<IActionResult> Load()
    {
        var query = new LoadHotelsQuery();
        var loadHotelsResult = await _mediator.Send(query);

        return loadHotelsResult.Match(
            loadHotelsResult => Ok(_mapper.Map<LoadHotelsResponse>(loadHotelsResult)),
            errors => Problem(errors));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Fetch(string id)
    {
        var query = _mapper.Map<FetchHotelQuery>(new { id = id });
        var fetchHotelResult = await _mediator.Send(query);

        return fetchHotelResult.Match(
            fetchHotelResult => Ok(_mapper.Map<HotelResponse>(fetchHotelResult)),
            errors => Problem(errors));
    }

    [HttpPost("")]
    public async Task<IActionResult> Create(CreateHotelRequest request)
    {
        var command = _mapper.Map<CreateHotelCommand>((request, UserId));
        var createHotelResult = await _mediator.Send(command);

        return createHotelResult.Match(
            createHotelResult => Ok(_mapper.Map<HotelResponse>(createHotelResult)),
            errors => Problem(errors));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(UpdateHotelRequest request, string id)
    {
        var command = _mapper.Map<UpdateHotelCommand>((request, id));
        var updateHotelResult = await _mediator.Send(command);

        return updateHotelResult.Match(
            updateHotelResult => Ok(_mapper.Map<HotelResponse>(updateHotelResult)),
            errors => Problem(errors));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var command = _mapper.Map<DeleteHotelCommand>(new { id = id });
        var deleteHotelResult = await _mediator.Send(command);

        return deleteHotelResult.Match(
            deleteHotelResult => Ok(_mapper.Map<HotelResponse>(deleteHotelResult)),
            errors => Problem(errors));
    }
}
