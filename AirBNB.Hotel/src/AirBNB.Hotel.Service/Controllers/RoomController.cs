using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AirBNB.Hotels.Service.Entities;
using AirBNB.Hotels.Service.Dtos;
using AirBNB.Hotels.Service.Services;

namespace AirBNB.Hotels.Service.Controllers
{
    [Route("api/room/{adminId}")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly RoomService _roomService;
        public RoomController(RoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("{hotelId}"), Authorize]
        public async Task<ActionResult<List<Room>>> Load([FromRoute] int hotelId)
        {
            try
            {
                var rooms = await _roomService.Load(hotelId);
                return Ok(rooms);
            }
            catch (System.Exception err)
            {
                Response.StatusCode = 500;
                return Content(err.ToString());
            }
        }

        [HttpGet("{id}"), Authorize]
        public async Task<ActionResult<Room>> Fetch([FromRoute] int id)
        {
            try
            {
                var room = await _roomService.Fetch(id);
                return Ok(room);
            }
            catch (System.Exception err)
            {
                Response.StatusCode = 500;
                return Content(err.ToString());
            }
        }

        [HttpPost, Authorize]
        public async Task<ActionResult<Room>> Create([FromRoute] int adminId, CreateRoomDto request)
        {
            try
            {
                var room = await _roomService.Create(adminId, request);
                return Ok(room);
            }
            catch (System.Exception err)
            {
                Response.StatusCode = 500;
                return Content(err.ToString());
            }
        }

        [HttpPatch("{id}"), Authorize]
        public async Task<ActionResult<Room>> Update([FromRoute] int adminId, [FromRoute] int id, [FromBody] UpdateRoomDto request)
        {
            try
            {
                var room = await _roomService.Update(adminId, id, request);
                return Ok(room);
            }
            catch (System.Exception err)
            {
                Response.StatusCode = 500;
                return Content(err.ToString());
            }
        }

        [HttpDelete, Authorize]
        public async Task<ActionResult<Room>> Delete([FromRoute] int adminId, int id)
        {
            try
            {
                await _roomService.Delete(adminId, id);
                return Ok();
            }
            catch (System.Exception err)
            {
                Response.StatusCode = 500;
                return Content(err.ToString());
            }
        }

        [HttpGet("room-book-dates/{id}"), Authorize]
        public async Task<ActionResult> getRoomBookDates([FromRoute] int id)
        {
            try
            {
                var dates = await _roomService.getRoomBookDates(id);
                return Ok(dates);
            }
            catch (System.Exception err)
            {
                Response.StatusCode = 500;
                return Content(err.ToString());
            }
        }

        [HttpPut("book-room/{id}"), Authorize]
        public async Task<ActionResult> BookRoom([FromRoute] int id, [FromBody] CreateBookDto request)
        {
            try
            {
                await _roomService.BookRoom(id, request);
                return Ok();
            }
            catch (System.Exception err)
            {
                Response.StatusCode = 500;
                return Content(err.ToString());
            }
        }

        [HttpDelete("unbook-room/{dateId}"), Authorize]
        public async Task<ActionResult> UnbookRoom([FromRoute] int dateId)
        {
            try
            {
                await _roomService.UnbookRoom(dateId);
                return Ok();
            }
            catch (System.Exception err)
            {
                Response.StatusCode = 500;
                return Content(err.ToString());
            }
        }
    }
}