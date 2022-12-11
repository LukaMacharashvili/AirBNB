using AirBNB.Application.BookDates.Commands.BookRoom;
using AirBNB.Application.BookDates.Commands.UnbookRoom;
using AirBNB.Application.BookDates.Queries.LoadBookDates;
using AirBNB.Application.Rooms.Commands.CreateRoom;
using AirBNB.Application.Rooms.Commands.DeleteRoom;
using AirBNB.Application.Rooms.Commands.UpdateRoom;
using AirBNB.Application.Rooms.Queries.FetchRoom;
using AirBNB.Application.Rooms.Queries.LoadRooms;
using AirBNB.Contracts.BookDates;
using AirBNB.Contracts.Rooms;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirBNB.Api.Controllers;

[AllowAnonymous]
[Route("auth/{hotelId}")]
public class RoomController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public RoomController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("")]
    public async Task<IActionResult> Load(string hotelId)
    {
        var query = _mapper.Map<LoadRoomsQuery>(new { HotelId = hotelId });
        var loadRoomsResult = await _mediator.Send(query);

        return loadRoomsResult.Match(
            loadRoomsResult => Ok(_mapper.Map<LoadRoomsResponse>(loadRoomsResult)),
            errors => Problem(errors));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Fetch(string id)
    {
        var query = _mapper.Map<FetchRoomQuery>(new { Id = id });
        var fetchRoomResult = await _mediator.Send(query);

        return fetchRoomResult.Match(
            fetchRoomResult => Ok(_mapper.Map<RoomResponse>(fetchRoomResult)),
            errors => Problem(errors));
    }

    [HttpPost("")]
    public async Task<IActionResult> Create(CreateRoomRequest request, string hotelId)
    {
        var command = _mapper.Map<CreateRoomCommand>((request, hotelId));
        var createRoomResult = await _mediator.Send(command);

        return createRoomResult.Match(
            createRoomResult => Ok(_mapper.Map<RoomResponse>(createRoomResult)),
            errors => Problem(errors));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(UpdateRoomRequest request, string id)
    {
        var command = _mapper.Map<UpdateRoomCommand>((request, id));
        var updateRoomResult = await _mediator.Send(command);

        return updateRoomResult.Match(
            updateRoomResult => Ok(_mapper.Map<RoomResponse>(updateRoomResult)),
            errors => Problem(errors));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var command = _mapper.Map<DeleteRoomCommand>(new { Id = id });
        var deleteRoomResult = await _mediator.Send(command);

        return deleteRoomResult.Match(
            deleteRoomResult => Ok(_mapper.Map<RoomResponse>(deleteRoomResult)),
            errors => Problem(errors));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> LoadBookDates(string id)
    {
        var command = _mapper.Map<LoadBookDatesQuery>(new { RoomId = id });
        var loadBookDatesResult = await _mediator.Send(command);

        return loadBookDatesResult.Match(
            loadBookDatesResult => Ok(_mapper.Map<LoadBookDatesResponse>(loadBookDatesResult)),
            errors => Problem(errors));
    }

    [HttpPut("/booking/{id}")]
    public async Task<IActionResult> BookRoom(BookRoomRequest request, string id)
    {
        var command = _mapper.Map<BookRoomCommand>((request, id));
        var bookRoomResult = await _mediator.Send(command);

        return bookRoomResult.Match(
            bookRoomResult => Ok(_mapper.Map<BookDateResponse>(bookRoomResult)),
            errors => Problem(errors));
    }

    [HttpDelete("/booking/{id}")]
    public async Task<IActionResult> UnbookRoom(string id)
    {
        var command = _mapper.Map<UnbookRoomCommand>(new { Id = id });
        var unbookRoomResult = await _mediator.Send(command);

        return unbookRoomResult.Match(
            unbookRoomResult => Ok(_mapper.Map<BookDateResponse>(unbookRoomResult)),
            errors => Problem(errors));
    }
}
